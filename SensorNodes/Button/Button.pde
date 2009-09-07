const int buttonPin = 7;     // the number of the pushbutton pin
int buttonState = 0;         // variable for reading the pushbutton status

void setup() {
  pinMode(buttonPin, INPUT);     
  Serial.begin(9600); // open serial
}

void loop(){
  // read the state of the pushbutton value:
  delay(2000);
  Serial.print("b:");
  Serial.print(digitalRead(buttonPin));
  Serial.print(",");
}
