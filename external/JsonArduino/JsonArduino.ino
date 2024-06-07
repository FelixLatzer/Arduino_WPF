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
  // Check if there's data to read from the serial port
  if (Serial.available())
  {
    // Read the incoming data
    int index = 0;
    while (Serial.available() && index < sizeof(jsonBuffer) - 1)
    {
      jsonBuffer[index++] = Serial.read();
    }
    jsonBuffer[index] = '\0'; // Null-terminate the JSON string

    // Check if it's a request for the current configuration
    if (strcmp(jsonBuffer, "GET_CONFIG") == 0)
    {
      // Create a JSON document to hold the pin configuration
      StaticJsonDocument<capacity> doc;

      // Add each pin's configuration to the JSON document
      for (int pin = 0; pin < 20; ++pin) // Assuming pins 0 to 19
      {
        JsonObject pinConfig = doc.createNestedObject(String(pin));
        pinConfig["mode"] = "UNKNOWN"; // Replace with actual mode retrieval logic
        pinConfig["state"] = digitalRead(pin); // Read the current state of the pin
      }

      // Serialize the JSON document to a string
      String jsonString;
      serializeJson(doc, jsonString);

      // Send the JSON string over the serial port
      Serial.println(jsonString);
    }
  }

  // Other loop logic here
  delay(1000); // Placeholder delay
}
