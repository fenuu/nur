// ---------------------------------------------------------------------------
// Example NewPing library sketch that does a ping about 20 times per second.
// ---------------------------------------------------------------------------

#include <NewPing.h>

#define TRIGGER_PIN  12  // Arduino pin tied to trigger pin on the ultrasonic sensor.
#define ECHO_PIN     11  // Arduino pin tied to echo pin on the ultrasonic sensor.
#define MAX_DISTANCE 200 // Maximum distance we want to ping for (in centimeters). Maximum sensor distance is rated at 400-500cm.
// Include the Servo library 
#include <Servo.h> 
// Declare the Servo pin 
int servoPin = 3; 
// Create a servo object 
Servo Servo1;
NewPing sonar(TRIGGER_PIN, ECHO_PIN, MAX_DISTANCE); // NewPing setup of pins and maximum distance.

void setup() {
  Serial.begin(115200); // Open serial monitor at 115200 baud to see ping results.
  Servo1.attach(servoPin); 
  Servo1.write(0);
  
  
}

void loop() {
                       // Wait 50ms between pings (about 20 pings/sec). 29ms should be the shortest delay between pings.
  int minu=200;
  int deg;
  int i;
  Servo1.write(0);
  delay(2000);
                     // Make servo go to 0 degrees 
   Servo1.write(180);
    for(int i=0;i<=180;i+=9) 
      {
        delay(20);
        Serial.print("Ping: ");
        Serial.print(sonar.ping_cm());
        Serial.println("cm");
    

     if(sonar.ping_cm()<minu && sonar.ping_cm()!=0)
       {
             minu=sonar.ping_cm();
             deg=i;
        }
      }
   
    Servo1.write(deg);
    delay(1000); 
  
 
   
}
