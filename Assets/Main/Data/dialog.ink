VAR suspicion = 0

// Accounting
CONST Jerry = 1     // Asshole
                    // Very bro-ish
                    // Has problems with HR
CONST Janet = 2     // Airhead
                    //Accused of stealing money - doesn't really get the gravity of this
// Marketing
CONST Felicity = 3  // Director
                    // No sense of humor
                    // Mean highschool girl all grown up, 
                    // Cat lady
                    // Finds James (IT mean guy) attractive
CONST Jimmy = 4     // Old rich hippie
                    // Always searching for the next big something spiritually, never finding it
                    // Makes his way through live on confidence and bullshit
                    // Impressed by bizarre displays of dominace
// HR
CONST Margaret = 5  // Older woman
                    // Sweet
                    // Lowkey horny
CONST Sarah = 6     // Young ingénue (young girl, sweet, innocent)
                    // Afraid of confronting people - this causes problems with her position in HR
// IT support
CONST James = 6     // "hum Actually-" guy - can't fail to take the bait if someone says something wrong and has to correct them
                    // Thinks everyone he is smarter than everyone
                    // Takes on the tasks of Ralph all the time
CONST Ralph = 7     // Comedy relief
                    // Big guy, childlike (a bit dumb)
// Interns
CONST Bradley = 8   // Loves the job - has fully drank the koolaid
                    // Doesn't get along with Rebbeca
CONST Rebbeca = 9   // Hates the job - overworked and without pay                 // Doesn't get along with Bradley
//Janitor
CONST Will = 10     // Mysterious with very little to say
                    // Everybody thinks he has definitely killed some people

VAR character = 0

~character=Jerry
Whoa there mate, watch where you're going! 
Wait - Do I know you? 
My name is Jerry, from Accounting.
Where are you from again?
 *  mistype
    Hmmm, okay...
    ~suspicion+=10
    -> janet
 *  Human Resources
    Ah, y'all are real sensitive nowadays, aren't ya?
    -> janet
 *  IT Support
    Oh really? Could you fix my computer, it has an error
    -> janet
 *  Janitorial Services
    Ah! You keep on cleaning those toilets. That's where I spend most of my day!
    -> janet
 *  Accounting
    I haven't seen you around the office?
    -> janet
    ~suspicion+=10
 *  Acounting Assistance
    I haven't seen you around the office?
 ** mistype
    Hmmm, okay...
    ~suspicion+=10
    -> janet
 ** You must be blind
    Hmmm, okay...
    ~suspicion+=10
    -> janet
 ** I only assist juniors
    Hmmm, okay...
    ~suspicion+=10
    -> janet
 
 ==janet==
Did you hear Janet was caught with her hand in petty cash?
 *  mistype
    Hmmm, okay...
    ~suspicion+=10
 *  Totally!
 *  Not Janet
    I know right? She seems like such a little sweetheart... Guess the quiet ones are the naughtiest!
 *  Who?
    Where have you been? This is all everyone on the upper floors keeps talking about!
    ~suspicion+=10
====
-> END
