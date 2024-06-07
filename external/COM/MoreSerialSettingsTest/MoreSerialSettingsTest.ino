void setup() 
{
  Serial.begin(9600);
  while (!Serial) {;}
  Serial.println("Arduino Mega2560 Serial Test Program");
}

void loop()
{
  testSerialConfig(9600, SERIAL_8N1);
  testSerialConfig(19200, SERIAL_8E1);
  testSerialConfig(38400, SERIAL_8O2);
  testSerialConfig(57600, SERIAL_7N1);
  testSerialConfig(115200, SERIAL_8E2);
  delay(5000);
}

void testSerialConfig(long baudRate, uint8_t config)
{
  Serial.end();
  Serial.begin(baudRate, config);
  while (!Serial) {;}

  Serial.print("Testing configuration: ");
  Serial.print("Baud rate: ");
  Serial.print(baudRate);
  Serial.print(", Config: 0x");
  Serial.println(config, HEX);
  Serial.println("Hello from Arduino Mega2560!");
  delay(1000);
}
