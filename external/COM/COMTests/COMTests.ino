#include <Arduino.h>

void setup()
{
  Serial.begin(9600);
  while (!Serial)
  {
    ; // Wait for serial port to connect. Needed for native USB port only
  }
  Serial.println("Arduino Serial Config Test Initialized");
}

void loop()
{
  if (Serial.available() > 0)
  {
    // Read the incoming byte
    char command = Serial.read();

    if (command == 'C')
    {
      while (Serial.available() < 5)
      {
        // Wait for all bytes to arrive (5 bytes for baud rate)
      }

      // Read baud rate (4 bytes, MSB first)
      uint32_t baudRate = 0;
      baudRate |= ((uint32_t)Serial.read() << 24);
      baudRate |= ((uint32_t)Serial.read() << 16);
      baudRate |= ((uint32_t)Serial.read() << 8);
      baudRate |= ((uint32_t)Serial.read());

      // Read parity (1 byte)
      char parity = Serial.read();

      // Read data bits (1 byte)
      uint8_t dataBits = Serial.read();

      // Read stop bits (1 byte)
      uint8_t stopBits = Serial.read();

      // Send acknowledgment
      Serial.println("Configuring Serial...");

      // Configure serial with new settings
      configureSerial(baudRate, parity, dataBits, stopBits);
    }
  }
}

void configureSerial(uint32_t baudRate, char parity, uint8_t dataBits, uint8_t stopBits)
{
  // Close the existing serial connection
  Serial.end();

  // Set up serial configuration
  uint8_t config = SERIAL_8N1;

  // Data bits
  switch (dataBits)
  {
    case 5:
      config = (config & ~0x18) | 0x00;
      break;
    case 6:
      config = (config & ~0x18) | 0x08;
      break;
    case 7:
      config = (config & ~0x18) | 0x10;
      break;
    case 8:
      config = (config & ~0x18) | 0x18;
      break;
  }

  // Parity
  switch (parity)
  {
    case 'N': // None
      config = (config & ~0x30) | 0x00;
      break;
    case 'E': // Even
      config = (config & ~0x30) | 0x20;
      break;
    case 'O': // Odd
      config = (config & ~0x30) | 0x30;
      break;
  }

  // Stop bits
  if (stopBits == 2)
  {
    config = (config & ~0xC0) | 0x80;
  }
  else
  {
    config = (config & ~0xC0) | 0x00;
  }

  // Reinitialize serial with new settings
  Serial.begin(baudRate, config);
  while (!Serial)
  {
    ; // Wait for serial port to connect
  }
  Serial.println("Serial Configured");
}
