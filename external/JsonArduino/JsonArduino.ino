#include <ArduinoJson.h>

const size_t capacity = JSON_OBJECT_SIZE(10) + 200; // Adjust capacity based on expected JSON size
char jsonBuffer[200];

void setup()
{
  Serial.begin(9600);

  while (!Serial)
  {
    // Wait for serial port to connect
  }

  Serial.println("Waiting for JSON config...");
  
  // Wait until we receive a valid JSON
  while (!Serial.available())
  {
    delay(100);
  }

  // Read JSON from serial
  int index = 0;
  while (Serial.available() && index < sizeof(jsonBuffer) - 1)
  {
    jsonBuffer[index++] = Serial.read();
  }
  jsonBuffer[index] = '\0'; // Null-terminate the JSON string

  // Parse JSON
  StaticJsonDocument<capacity> doc;
  DeserializationError error = deserializeJson(doc, jsonBuffer);
  
  if (error)
  {
    Serial.print(F("deserializeJson() failed: "));
    Serial.println(error.c_str());
    return;
  }

  // Iterate over the JSON object
  JsonObject root = doc.as<JsonObject>();
  for (JsonPair kv : root)
  {
    int pin = atoi(kv.key().c_str());
    JsonObject pinConfig = kv.value().as<JsonObject>();

    const char* mode = pinConfig["mode"];
    if (mode)
    {
      if (strcmp(mode, "OUTPUT") == 0)
      {
        pinMode(pin, OUTPUT);
        if (pinConfig.containsKey("state"))
        {
          int state = pinConfig["state"];
          digitalWrite(pin, state);
        }
      }
      else if (strcmp(mode, "INPUT") == 0)
      {
        pinMode(pin, INPUT);
      }
      else if (strcmp(mode, "INPUT_PULLUP") == 0)
      {
        pinMode(pin, INPUT_PULLUP);
      }
    }
  }

  Serial.println("Configuration complete!");
}

void loop()
{
  Serial.println("Hello world!");
  delay(1000); 
}
