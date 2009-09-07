#include "WProgram.h"
void setup();
void loop();
void setup() { 
    Serial.begin(9600); // open serial
}

void loop() {
  delay(1000);
  Serial.print("p:");
  Serial.print(analogRead(0),DEC);
  Serial.print(",");
}

int main(void)
{
	init();

	setup();
    
	for (;;)
		loop();
        
	return 0;
}

