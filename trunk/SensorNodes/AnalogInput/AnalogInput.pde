void setup() { 
    Serial.begin(9600); // open serial
}

void loop() {
  delay(1000);
  Serial.print("p:");
  Serial.print(analogRead(0),DEC);
  Serial.print(",");
}
