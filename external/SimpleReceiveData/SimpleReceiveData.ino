#include <ArduinoJson.h>

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT); // Initialize pin 13 as OUTPUT, if necessary
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readString();
    Serial.print("Received JSON: ");
    Serial.println(input);

    StaticJsonDocument<200> doc;
    DeserializationError error = deserializeJson(doc, input);

    if (error) {
      Serial.print("Error in parsing JSON: ");
      Serial.println(error.c_str());
      return;
    }

    // Extract values from JSON array
    JsonObject obj = doc[0];
    int id = obj["Id"];
    String mode = obj["Mode"];
    int state = obj["State"];

    mode.toUpperCase();

    Serial.print("Parsed values - Id: ");
    Serial.print(id);
    Serial.print(", Mode: ");
    Serial.print(mode);
    Serial.print(", State: ");
    Serial.println(state);

    // Process based on mode
    if (mode == "OUTPUT") {
      pinMode(id, OUTPUT); // Set the pin mode to OUTPUT
      digitalWrite(id, state);
      Serial.println("Processed OUTPUT mode.");
    } else if (mode == "INPUT") {
      pinMode(id, INPUT); // Set the pin mode to INPUT
      int pinState = digitalRead(id);
      Serial.print("Current state of pin ");
      Serial.print(id);
      Serial.print(" is: ");
      Serial.println(pinState);
      StaticJsonDocument<200> response; // create a response object
      response["Id"] = id;
      response["Mode"] = "INPUT";
      response["State"] = pinState;
      serializeJson(response, Serial);
    } else {
      // Handle unsupported mode
      Serial.println("Unsupported mode received.");
    }
  }
}
