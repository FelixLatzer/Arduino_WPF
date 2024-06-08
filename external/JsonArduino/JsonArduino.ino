#include <ArduinoJson.h>

const size_t capacity = JSON_OBJECT_SIZE(20) + 200; // Adjust capacity based on expected JSON size

void setup()
{
  Serial.begin(9600);
  while (!Serial)
  {
    // Wait for serial port to connect
  }

  // Create a JSON array to hold pin configurations
  DynamicJsonDocument doc(capacity);
  JsonArray pinsArray = doc.to<JsonArray>();

  // Add each pin's configuration to the JSON array
  for (int pin = 0; pin < 20; ++pin) // Assuming pins 0 to 19
  {
    JsonObject pinConfig = pinsArray.createNestedObject();
    pinConfig["id"] = pin;
    pinConfig["mode"] = "UNKNOWN"; // Replace with actual mode retrieval logic if needed
    pinConfig["state"] = digitalRead(pin); // Read the current state of the pin
  }

  // Serialize the JSON array to a string
  String jsonString;
  serializeJson(doc, jsonString);

  // Send the JSON string over the serial port
  Serial.println("JSON configuration (from setup):");
  Serial.println(jsonString);
}

void loop()
{
  // Create a JSON array to hold pin configurations
  DynamicJsonDocument doc(capacity);
  JsonArray pinsArray = doc.to<JsonArray>();

  // Add each pin's configuration to the JSON array
  for (int pin = 0; pin < 20; ++pin) // Assuming pins 0 to 19
  {
    JsonObject pinConfig = pinsArray.createNestedObject();
    pinConfig["id"] = pin;
    pinConfig["mode"] = "Unknown"; // Replace with actual mode retrieval logic if needed
    pinConfig["state"] = digitalRead(pin); // Read the current state of the pin
  }

  // Serialize the JSON array to a string
  String jsonString;
  serializeJson(doc, jsonString);

  // Send the JSON string over the serial port
  Serial.println("JSON configuration (from loop):");
  Serial.println(jsonString);

  // Delay between prints
  delay(1000); // Adjust the delay as needed
}
