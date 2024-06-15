#include <ArduinoJson.h>

void setup() {
  Serial.begin(9600);
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readString();
    Serial.print("Received JSON: ");
    Serial.println(input);

    StaticJsonDocument<1024> doc; // Adjust the size according to your needs
    DeserializationError error = deserializeJson(doc, input);

    if (error) {
      Serial.print("Error in parsing JSON: ");
      Serial.println(error.c_str());
      return;
    }

    // Iterate through each object in the JSON array
    for (JsonVariant obj : doc.as<JsonArray>()) {
      int id = obj["id"] | obj["Id"];           // Attempt to access both "id" and "Id"
      String mode = obj["mode"] | obj["Mode"];  // Attempt to access both "mode" and "Mode"
      int state = obj["state"] | obj["State"];  // Attempt to access both "state" and "State"

      Serial.print("Parsed values - Id: ");
      Serial.print(id);
      Serial.print(", Mode: ");
      Serial.print(mode);
      Serial.print(", State: ");
      Serial.println(state);

      // Process based on mode
      if (mode == "OUTPUT" || mode == "output") {  // Handle both "OUTPUT" and "output"
        pinMode(id, OUTPUT);        // Set the pin mode to OUTPUT
        digitalWrite(id, state);    // Set the pin state to the provided value
        Serial.println("Processed OUTPUT mode.");
      } else if (mode == "INPUT" || mode == "input") {  // Handle both "INPUT" and "input"
        pinMode(id, INPUT);         // Set the pin mode to INPUT
        int pinState = digitalRead(id);
        Serial.print("Current state of pin ");
        Serial.print(id);
        Serial.print(" is: ");
        Serial.println(pinState);
      } else {
        // Handle unsupported mode
        Serial.println("Unsupported mode received.");
      }
    }
  }
}
