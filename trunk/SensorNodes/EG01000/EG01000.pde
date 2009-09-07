#if defined(__AVR_ATmega1280__)
extern HardwareSerial Serial1;
extern HardwareSerial Serial2;
extern HardwareSerial Serial3;
#endif

#define DEBUG 0
#define BURST 10

int i=0;
int j=0;
int runLength = 1;

char buffer[1000];

short unsigned int dataLast;
short unsigned int data;

void setup()
{
  // HW serial
  Serial.begin(9600);
  // SW serial
  Serial1.begin(9600);

  // simulation mode
  delay(1000);
  Serial1.print('M');
  delay(1000);
}

void loop()
{
  eg0100();
}

void pox()
{
 
}
void eg0100()
{
  //  char *point;
  if (Serial1.available()) {
    dataLast = data;
    data = Serial1.read();
    switch(data)
    {
      // wave marker bit
    case 248:
      i = 1;
      break;
      // pulse marker bit
    case 250:
      i = 2;
      break;
      // info marker bit
    case 251:
      i = 3;
      break;
      // else
    default:
      switch(i)
      {
      case 1:

        if( j+1 < BURST && data == dataLast ) {
          runLength++;
          if ( runLength < 10)
            j++;
        }
        else {
          j++;
          char c[4];
          if ( runLength > 1){
            strcat(buffer,itoa(runLength,c,10));
            strcat(buffer,":");
            runLength = 1;
          }
          strcat(buffer,itoa(data,c,10));
          strcat(buffer,",");
        }
        break;

      case 2:
        // *pulse++ = data;
        break;
      case 3:
        //  *info++ = data;
        break;               
      default:
        break;
      }
      break;
    }
  }
  if(j == BURST)
  {
    Serial.print(buffer);
    *buffer = '\0';
    j=0;
    //delay(10);
  }
  if (DEBUG)
    Serial.println("*EOL*");
  // *info = '\0';
  // *pulse = '\0';xc`asdadcqweq
}
