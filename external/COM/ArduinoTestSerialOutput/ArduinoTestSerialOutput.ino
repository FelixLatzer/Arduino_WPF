void setup()
{
  Serial.begin(9600);
  while (!Serial)
  {
    ;
  }
}

void loop()
{
  Serial.println("Hello from Arduino Mega2560! Testing serial communication.");
  Serial.println("Current configuration: Baud rate: 9600, Parity: None, Data bits: 8, Stop bits: 1");
  delay(1000);
}
