VAR suspicion = 0

CONST Jerry = 1
CONST Janet = 2 // Airhead Accused of stealing money
CONST Will = 3 // Janitor Hates everyone in the building
CONST Tim = 4 
CONST Giles = 5
CONST James = 6 // Marketing 
CONST Ralph = 7
CONST Margaret = 8
CONST Miriam = 9
CONST Benedict = 10 // CEO

VAR character = 0

~character=Jerry
Hello my name is Jerry from Accounting.
Where are you from again?
 *  mistype
    Hmmm, okay...
    ~suspicion+=10
 *  Human Resources
    Ah, y'all are real sensitive nowadays, aren't ya?
 *  IT Support
    Oh really? Could you fix my computer, it has an error
 *  Janitorial Services
    Ah! You clean those toilets. That's where I spend most of my time!
 *  Accounting
    I haven't seen you around the office?

    
-> END
