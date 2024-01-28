VAR suspicion = 0

// Accounting
CONST Jerry = 1     // Asshole
                    // Very bro-ish
                    // Has problems with HR
// Marketing
CONST Jimmy = 2     // Comedy relief
                    // Big guy
                    // Childlike (a bit dumb) 
// HR
CONST Margaret = 3  // Older woman
                    // Sweet
                    // Lowkey horny
CONST Sarah = 4     // Young ingénue (young girl, sweet, innocent)
                    // Afraid of confronting people - this causes problems with her position in HR
// IT support
CONST James = 5     // "hum Actually-" guy - can't fail to take the bait if someone says something wrong and has to correct them
                    // Thinks everyone he is smarter than everyone
                    // Takes on the tasks of Ralph all the time
// Interns
CONST Bradley = 6   // Loves the job - has fully drank the koolaid
                    // Doesn't get along with Rebbeca
CONST Rebbeca = 7   // Hates the job - overworked and without pay                 // Doesn't get along with Bradley
//Upper management
CONST Giles = 8    // CEO Son
                    // 12 y.o., Fortnite
CONST Miriam = 9   // No bullshit
                    // Competent
                    // Weakspot: Tim
CONST Tim = 10      // Incompetent brother in law of Miriam
                    // Just as scared as you of being found out
CONST Benedict = 11 // CEO 
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
    Oh really? Could you fix my computer, it has an error.
 *  Janitorial Services
    Ah! You keep on cleaning those toilets. 
    That's where I spend most of my day!
 *  Accounting
    ~suspicion+=10
    I haven't seen you around the office, are you pulling my leg?
 *  mistype
    ~suspicion+=10
    Hmmm, okay...

- Did you hear Janet was caught with her hand in petty cash?
 *  Bad move!
    Crazy right? The first rule of stealing is don't get caught! 
    What can you expect from a silly blonde like that.
 *  Surely not Janet!
    ~suspicion-=5
    I know right? She seems like such a little sweetheart... 
    Guess the quiet ones are the naughtiest!
 *  Who?
    ~suspicion+=10
    Where have you been? 
    This is all everyone on the upper floors keeps talking about!
 *  mistype
    ~suspicion+=10
    You good mate?

- Anyway, how are you liking the new tax forms? 
- Pretty cool right? My idea of course.
 * They suck
    ~suspicion+=10
    How dare you?! 
    Those forms are a bureaucratic masterpiece!
 * What forms?
    ~suspicion+=20
    Didn't you receive the newsletter update? Strange...
 * I love them to death!
    ~suspicion-=10
    Of course you do! Those forms are a piece of bureaucratic beauty!
 *  mistype
    ~suspicion+=10   
    Sorry, I didn't quite catch that...
    
- Well then! I'm going to grab some more beer and checkout the babes from marketing, bye!

//-----------------------Char change-----------------------
~character=Margaret
- Someone keeps printing pics of their butt on the office printers...
 * Jerry?
   I don't know about that, Jerry's butt is very nicely shaped - not that I have been looking at it!
 * Butt?
   You heard me right son. Just pages and pages of a round, perky butt...
 *  mistype
    ~suspicion+=10  
    Are you feeling well love? You're slurring your words...

- I keep telling them that the best solution for these problems is to check everyone's butts!
 * Agreed!
    Ahahah! Someone that knows what's up!
 * Weird
    ~suspicion+=10 
    Is it? Don't people like butts?
 * Inappropriate...
    ~suspicion+=10 
    Oh, apologies, nobody's ever complained to my face...
    
- It's been a crazy month, I'm happy we get this party to relax a bit!
 * Deserved!
    ~suspicion-=10
    Aw thank you sweetheart! 
    You know just what to say to melt this old lady's heart!
 * From what?
    ~suspicion+=10
    I'll have you know we are very busy down at HR! Cheeky!

- Well, keep on the lookout for anyone sitting on a printer, won't you love? Cheers!

//-----------------------Char change-----------------------
~character=Giles
- Are you the driver? 
- Take me home right now!
 * Why?
    ~suspicion+=15
    Do you know who my daddy is? I'll have you fired!
 * And you are?
    ~suspicion+=15
    What do you mean? I'm Giles and my daddy is the boss of this company!
 * I'm not the driver
    Ugh that sucks! 
    A new hotdog skin just dropped and I have a bunch of VBucks burning a whole in my pocket!
 * What?
    ~suspicion+=5
    Man did they hire a "special guy" again?
 * mistype
    ~suspicion+=5
    Can't you talk?
    
- I can't believe I have to be here! 
- I could be ranking up in fortnite right now!
 * Fortnite?
    ~suspicion+=10
    You don't know Fortnite? Are you like a boomer or something?
 * What's your rank?
    I'm silver 3, I'm going to go pro for sure!
    Daddy is going to buy an e-sports team for my birthday!
 * Leave?
    ~suspicion+=10
    And walk home? Are you actually insane or just drunk?
 * Ask your dad?
    Don't you think I've thought of that? I can't find him anywhere!

- Also I demanded they get turkey quiches for today and there are none!
 * Quiches?
    ~suspicion+=10
    Of course you wouldn't know what a  quiche is. 
    A quiche is a... it's like a type of... well it doesn't matter! 
    It's delicious!
 * Too bad!
    ~suspicion+=20
    You think you're funny? My father will hear about this!
 * I saw some over there
    Oh cool, thanks!
    
- I'm going to check if my dad will let me use his computer. Bye.

//-----------------------Char change-----------------------
~character=Bradley

- Oh hi! I don't think we've met yet! 
- My name is Bradley! 
- I've just begun my internship here!
 * Okay...
    Yeah, and you know, I already feel so helpful! 
    Everyone keeps asking me for the most random stuff, they really must like my work!
    The CEO even asked me to accompany his child to a gaming tournament once!
    That's trust right there!
 * Don't talk to me
    ~suspicion+=5
    Oh uh ok, is this like a hazing thing? 
    Everyone keeps telling me that ahaha....
 * Internship? Neat.
    Yes! Can you believe it? This company is amazing! 
    Such productive work. You really feel like you're changing things in the world... 
    You know... with the widgets we make and all... those are real helpful!

- Anyway, what department are you on? 
- Don't think I've seen your face around. 
- I'm good with faces you know?
 * Intern!
    ~suspicion+=20
    That is definitely odd... 
    I haven't heard of any new interns since they hired Rebecca and I...
    Weird...
 * I'm in accounting
    ~suspicion-=10  
    Oh! What are your thoughts on the new tax forms? 
    Jerry keeps bragging about them. I hope one day I'll be able to do work like that.
 * Don't work here
    ~suspicion+=30
    Aahahah very funny sir! 
    Like someone would just walk in from the street and join a random party! 
    hahaa... ahah... uh...

- Oh sorry give me a second. Jerry just asked me to go grab more beer for the bar!

//-----------------------Char change-----------------------
~character=Rebbeca

- Oh my god, thank god he's gone... 
- I'm Rebbeca by the way. Also an intern.
 * He's a bit much
    ~suspicion-=10 
    He's crazy! This job suuucks!
    Some kind of Stockholm syndrome for sure.
    I swear to god I can't wait to for this internship to be over and done with!
 * Interns multiplying
    Ahaha good one! 
    Trust me, I hate this more than you do.

- They're using us. We do all the grunt work, yet we get paid in pence?
- They even have me driving the CEO's son sometimes...
 * Quit
    ~suspicion+=10
    Wow great advice! 
    Wouldn't be here if I didn't need the job.
 * Sucks to be you
    Ahahah funny! You should try stand up!
 * Complain
    ~suspicion+=10
    Are you sure you work here? 
    HR would never do anything about this...
    
- I'm going to go join the rest of the intern crew in the bathroom and smoke a doobie... 
- You know where to find us if you're down
- Bye!

//-----------------------Char change----------------------
~character=James
- I can't believe the CEO brought his 12 year old son to the party. 
 * Spoiled brat
    ~suspicion-=10
    Oh my god, yes!
    I couldn't believe it when I heard that he spent my annual salary on that video game...
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
~character=Tim

- Heeey man -hic- how you doin?
 * You good?
    ~suspicion-=5
    Yeah man, I'm greaa-hic-aat!
 * Heeey!
    Ehehe hey... do you know where my nephew went? I was s'posed to drive him to some place called fortnite?
 * Want water?
    ~suspicion+=10
    Water?! Are you crazy? Everyone knows I only drink buckfast!
 * Sit?
    Nah man, I've got to danceee! I can feel the music in my bones!
    
- Hmmm, what floor you on? Don't think I've seen your face before...
 * Don't work here
    ~suspicion-=5
    Dude, me neither. Cheers!
 * I don't know
    I get you! This building is so big it's easy to get lost.
 * Yours
    I'm so sorry, I didn't mean to be rude, I'm not good with faces.

- So, how are you enjoying the free food and open bar?
 * Great!
    Free food always tastes the best!
 * No quiche
    Oh shoot! I was supposed to get the quiche...
 * Needs more wine!
    Right?
    I swear there was more wine there before I drank it.

Oh no!
My cup is empty again, how does this keep happening? 
Bye!
    
//-----------------------Char change-----------------------
~character=Jimmy

- I can't believe this sandwich theft keeps happening! I'll have to write an email to HR again, ugh...
 * What's up?
    ~suspicion+=10
    What do you mean what's up?! We have a very serious problem of sandwich thievery!
 * Maybe Tim? 
    Do you think he's behind this?! He does have little rat thief hands...
 * Justice for the sandwich!
    ~suspicion-=10
    Yes! I demand the culprit be brought to justice!

- Can you believe Margaret from HR told me, it wasn't that big of a deal? She's crazy!
 * Overreacting
    ~suspicion+=20
    Overreacting?! I'm not overreacting! It's much more than that! 
    You don't take a man's sandwich like that!
 * Maybe Tim?
    ~suspicion-=5
    Yeah! I think I WILL ask Tim, mighteven smell his breath, see if it smells like turkey
 * Crazy
    ~suspicion-=5
    Finally, someone that agrees with me! We deserve to be heard!

- They really thought having turkey mini quiches here would distract me from what really matters! Fools!
 * Mini quiches?
    Oh, I've eaten the last 20, my bad...
 * It matters?
    ~suspicion+=10
    We've been over this! You don't play with a man's food!
 * Corruption!
    ~suspicion-=10
    You're right! They think we can't fight back against this oppressive system!
    This goes all the way to the top!
 * Turkey sucks!
    ~suspicion+=11
    Blasphemy! I'll make a complaint to HR about this!

- Don't be fooled, they're only having this party to keep us quiet about our fridge rights! I'm going to go find someone from HR!

//-----------------------Char change-----------------------
~character=Benedict

- You look lost son.
- Do you even know what we make here at Redundant Solutions?

 * Arrogance?
    ~suspicion-=5
    Ha! You've got guts boy, I like that. Speak to Miss Philips, tell her to bring you along on my next Ayahuasca retreat.
 * Widgets?
    ~suspicion-=10
    That's right, the best damn widgets in the world, and don't you forget it
 * Photocopiers?
    ~suspicion+=20
    What are you talking about! We make widgets you idiot! Get out of my sight, before I fire you!

//-----------------------Char change-----------------------
~character=Sarah

- Did Jimmy go through here? Please help me hide!
 * Who?
    ~suspicion+=10
    You don't know Jimmy? Are you new here?
 * SandwichGate?
    Oh no he got to you too?! It's been weeks! WEEKS! Getting the same freaking email about a damn sandwich!
 * Yes!
    ~suspicion-=5
    Thank god, I can hang out here for a bit. He's been hunting the HR department to complain about his stupid sandwiches. AGAIN!
 * mistype
    ~suspicion+=10
    You're slurring your words!

//-----------------------Char change-----------------------
~character=Miriam

- And who might you be? I know everyone in this company.
 * Tim hired me
    Oh Tim... 
    Okay, carry on
 * Driver
    ~suspicion+=5
    So, my brother finally caved and hired a personal driver for the brat? 
    Seems unlikely...
 * Janitor
    I see! Well I don't really know the whole janitorial services team...
 * Intern?
    ~suspicion+=20
    Are you asking me if you're an intern here? That's definitely a bad way to about it.
 * Catering
    ~suspicion+=5
    Without a uniform? What firm did we hire?

=== fail ===
- I don't think you work here at all! I'm calling secuirty.


-> END
