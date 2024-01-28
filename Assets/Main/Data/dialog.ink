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
CONST Jimmy = 4     // Comedy relief
                    // Big guy
                    // Childlike (a bit dumb) 
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
// Interns
CONST Bradley = 7   // Loves the job - has fully drank the koolaid
                    // Doesn't get along with Rebbeca
CONST Rebbeca = 8   // Hates the job - overworked and without pay                 // Doesn't get along with Bradley
//Janitor
CONST Will = 9     // Mysterious with very little to say
                    // Everybody thinks he has definitely killed some people
//Upper management
CONST Giles = 10    // CEO Son, 12 y.o., Fortnite
CONST Miriam = 11   // No bullshit
                    // Competent
                    // Weakspot: Tim
CONST Tim = 12      // Incompetent brother in law of Miriam
                    // Just as scared as you of being found out
CONST Benedict = 13 // CEO 
                    // Very enlighted and in touch with his emotions, but is actually a bad boss
                    // Is always on the phone yelling at someone

VAR character = 0


~character=Jerry
Whoa there mate, watch where you're going! 
Wait - Do I know you? 
My name is Jerry, from Accounting.
Where are you from again?
 *  Human Resources
    Ah, y'all are real sensitive nowadays, aren't ya?
 *  IT Support
    Oh really? Could you fix my computer, it has an error
 *  Janitorial Services
    Ah! You keep on cleaning those toilets. That's where I spend most of my day!
 *  Accounting
    ~suspicion+=10
    I haven't seen you around the office?
 *  mistype
    ~suspicion+=10
    Hmmm, okay...

- Did you hear Janet was caught with her hand in petty cash?
 *  Dumb Move!
    ~suspicion-=5
    Crazy right? The first rule of stealing is don't get caught! What can you expect from a pretty blonde like that.
 *  Not Janet
    I know right? She seems like such a little sweetheart... Guess the quiet ones are the naughtiest!
 *  Who?
    ~suspicion+=10
    Where have you been? This is all everyone on the upper floors keeps talking about!
 *  mistype
    ~suspicion+=10
    Hmmm, okay...

- Anyway, how are you liking the new tax forms? Pretty cool right? My idea.
 * They suck
    ~suspicion+=10
    How dare you?! Those forms are a bureaucratic masterpiece!
 * What forms?
    ~suspicion+=20
    Didn't you receive the newsletter update? Strange...
 * Loving them!
    ~suspicion-=10
    Of course you are, Those forms are a piece of bureaucratic beauty!
 *  mistype
    ~suspicion+=10   
    Hmmm, okay...
    
- Well then! I'm going to grab some more beer and checkout the babes from marketing, bye!

//-----------------------Char change-----------------------
~character=Margaret
- Someone keeps printing pics of their butt on the office printers...
 * I'm pretty sure it's Tim
   I don't know about that, Tim's butt is very nicely shaped - not that I have been looking at it!
 * Butt?
   You heard me right son. Just pages and pages of a round, perky butt...
 * Getting complaints
   So many complaints! We get sent all the printed images, and I of course have to go through all of them to see if they belong to the same person!
 *  mistype
    ~suspicion+=10  
    Are you feeling well love? You're slurring your words...
    
//-----------------------Char change-----------------------
~character=Giles
- Are you the driver? Take me home right now!
 * No?
   Do you know who my daddy is? I'll have you fired!
 * Who are you
   What do you mean? I'm Giles and my daddy is the boss of this company!
 *  mistype
    Ugh, are you drunk? Gross!
    
//-----------------------Char change-----------------------
//~character=Bradley

//-----------------------Char change-----------------------
//~character=Rebbeca

//-----------------------Char change----------------------
//~character=Janet

//-----------------------Char change-----------------------
//~character=Will

//-----------------------Char change-----------------------
//~character=Felicity
- I can't believe the CEO brought his 12 year old son to the party. I guess it was his turn to look after the little rascal this weekend.
* Spoiled brat
  ~suspicion-=10
  Oh my god, yes!
  I couldn't believe it when I heard that he spent my annual salary on VBucks...
* Sweet child
  ~suspicion+=10
  Are you crazy? You think that spoiled brat is sweet?
  You haven't been here long have you?
* Demon spawn
  ~suspicion-=10
  Can you believe he just asked me to drive him home? Who does he think he is?
 * mistype
   ~suspicion+=10
   Ugh, are you drunk? Gross!

//-----------------------Char change-----------------------
//~character=Tim 

//-----------------------Char change-----------------------
//~character=Benedict

//-----------------------Char change-----------------------
~character=Jimmy
- I can't believe this sandwich theft keeps happening,! I'll have to write an email to HR again, ugh...
* What's up with the fridge?
  ~suspicion+=20
  What do you mean what's up?! We have a very serious problem of sandwich thievery!!
  
* Justice for the sandwich!
  ~suspicion-=20
  Yes! I demand the culprit be brought to justice!

//-----------------------Char change-----------------------
//~character=Miriam

//-----------------------Char change-----------------------
//~character=Sarah

//-----------------------Char change-----------------------
//~character=Will

//-----------------------Char change-----------------------
//~character=James


-> END
