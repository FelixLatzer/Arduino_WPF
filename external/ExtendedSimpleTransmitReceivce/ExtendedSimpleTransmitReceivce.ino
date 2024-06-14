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

    for (JsonObject obj : doc.as<JsonArray>()) {
      int id = obj["Id"];
      String mode = obj["Mode"];
      int state = obj["State"];

      Serial.print("Parsed values - Id: ");
      Serial.print(id);
      Serial.print(", Mode: ");
      Serial.print(mode);
      Serial.print(", State: ");
      Serial.println(state);

      // Process based on mode
      if (mode == "OUTPUT") {
        pinMode(id, OUTPUT); // Set the pin mode to OUTPUT
        digitalWrite(id, state); // Set the pin state to the provided value
        Serial.println("Processed OUTPUT mode.");
      } else if (mode == "INPUT") {
        pinMode(id, INPUT); // Set the pin mode to INPUT
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
