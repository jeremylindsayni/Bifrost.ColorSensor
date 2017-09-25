#include <hcsr04.h>
#include <TCS34725.h>

#define TRIG_PIN 12
#define ECHO_PIN 13

HCSR04 hcsr04(TRIG_PIN, ECHO_PIN);
TCS34725 tcs34725;

void setup() {
  Serial.begin(9600);

  if (!tcs34725.begin()) {
    Serial.println("No TCS34725 found ... check your connections");
    while (1);
  }
}

void loop() {
  tcs34725.Read();

  Serial.print("[");
  Serial.print(tcs34725.ToString());
  Serial.print(",");
  Serial.print(hcsr04.ToString());
  Serial.println("]");

  delay(500);
}
