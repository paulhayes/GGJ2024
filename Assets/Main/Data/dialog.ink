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

// IT support
CONST James = 4     // "hum Actually-" guy - can't fail to take the bait if someone says something wrong and has to correct them
                    // Thinks everyone he is smarter than everyone
                    // Takes on the tasks of Ralph all the time
// Interns
CONST Bradley = 5   // Loves the job - has fully drank the koolaid
                    // Doesn't get along with Rebbeca
CONST Rebbeca = 6   // Hates the job - overworked and without pay                             // Doesn't get along with Bradley
//Upper management
CONST Giles = 7    // CEO Son
                    // 12 y.o., Fortnite
CONST Miriam = 8   // No bullshit
                    // Competent
                    // Weakspot: Tim
CONST Tim = 9      // Incompetent brother in law of Miriam
                    // Just as scared as you of being found out
CONST Benedict = 10 // CEO 
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
    ~suspicion+=1
    How dare you?! 
    Those forms are a bureaucratic masterpiece!
 * What forms?
    ~suspicion+=15
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
    ~suspicion-=5
   I don't know about that, Jerry's butt is very nicely shaped - not that I have been looking at it!
 * Butt?
   You heard me right son. Just pages and pages of a round, perky butt...
 *  mistype
    ~suspicion+=10  
    Are you feeling well love? You're slurring your words...

- I keep telling them that the best solution for these problems is to check everyone's butts!
 * Agreed!
    ~suspicion-=10 
    Ahahah! Someone that knows what's up!
 * Weird
    ~suspicion+=10 
    Is it? Don't people like butts?
 * Inappropriate...
    ~suspicion+=20 
    Oh, apologies, nobody's ever complained to my face...
    
- It's been a crazy month, I'm happy we get this party to relax a bit!
 * Deserved!
    ~suspicion-=10
    Aw thank you sweetheart! 
    You know just what to say to melt this old lady's heart!
 * From what?
    ~suspicion+=15
    I'll have you know we are very busy down at HR! Cheeky!

- Well, keep on the lookout for anyone sitting on a printer, won't you love? Cheers!

//-----------------------Char change-----------------------
~character=Giles
- Are you the driver? 
- Take me home right now!
 * Why?
    ~suspicion+=20
    Do you know who my father is? I'll have you fired!
 * And you are?
    ~suspicion+=25
    What do you mean? I'm Giles and my father is the boss of this company!
 * I'm not the driver
    Ugh that sucks! 
    A new hotdog skin just dropped and I have a bunch of VBucks burning a whole in my pocket!
 * What?
    ~suspicion+=5
    Man did they hire a "special guy" again?
 * mistype
    ~suspicion+=10
    Can't you talk?
    
- I can't believe I have to be here! 
- I could be ranking up in fortnite right now!
 * Fortnite?
    ~suspicion+=10
    You don't know Fortnite? Are you like a boomer or something?
 * What's your rank?
    I'm silver 3, I'm going to go pro for sure!
    Dad is going to buy an e-sports team for my birthday!
 * Leave?
    ~suspicion+=10
    And walk home? Are you actually insane or just drunk?
 * Ask your dad?
    Don't you think I've thought of that? I can't find him anywhere!
 * mistype
    ~suspicion+=10
    Can't you talk?

- Also I demanded they get turkey quiches for today and there are none!
 * Quiches?
    ~suspicion+=5
    Of course you wouldn't know what a  quiche is. 
    A quiche is a... it's like a type of... 
    Well it doesn't matter! It's delicious!
 * Too bad!
    ~suspicion+=30
    You think you're funny? My father will hear about this!
 * mistype
    ~suspicion+=10
    Can't you talk?
    
- I'm going to check if my dad will let me use his computer. Bye.

//-----------------------Char change-----------------------
~character=Bradley

- Oh hi! I don't think we've met yet! 
- My name is Bradley! 
- I've just begun my internship here!
 * Ok...
    Yeah, and you know, I already feel so helpful! 
    Everyone keeps asking me for the most random stuff, they really must like my work!
    The CEO even asked me to accompany his child to a gaming tournament once!
    That's trust right there!
 * Don't talk to me
    ~suspicion+=5
    Oh uh, ok, is this like a hazing thing? 
    Everyone keeps telling me that ahaha....
 * Internship? Neat.
    ~suspicion-=5
    Yes! Can you believe it? This company is amazing! 
    Such productive work. You really feel like you're changing things in the world... 
    You know... with the widgets we make and all... those are real helpful!
 * mistype
    ~suspicion+=10
    You ok there?

- Anyway, what department are you on? 
- Don't think I've seen your face around. 
- I'm good with faces you know?
 * Intern!
    ~suspicion+=25
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
 * Janitor
    Oh really? 
    I don't really know much about our janitorial staff, but you are greatly appreciated! 
    Like the cogs on a well oiled machine, you know?
 * mistype
    ~suspicion+=10
    Can't understand you sir

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
    ~suspicion+=15
    Wow great advice! 
    Wouldn't be here if I didn't need the job.
 * Sucks to be you
    Ahahah funny! You should try stand up!
 * Complain
    ~suspicion+=15
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
    ~suspicion+=25
    Are you crazy? You think that spoiled brat is sweet?
    You haven't been here long have you?
 * Demon spawn
    ~suspicion-=10
    Can you believe he just asked me to drive him home? Who does he think he is?
 * mistype
   ~suspicion+=10
   Ugh, are you drunk already?

- Anyway this party sucks! 
- Can't even enjoy a turkey quiche without some dumb accountant asking my why his computer isn't working!
 * Quiche?
    Yeah man, that's the only reason I came up from the basement... 
    Huge disappointment.
 * Don't complain
    ~suspicion+=10
    Wow! No need to be rude!
    I was just making conversation.
 * Jerry?
    ~suspicion-=10
    Yes! He calls me at least once a week.
    I can't stand that guy, such a moron
 * Monitor's off
    That's a classic! It happens way too often...
 * On and off
    ~suspicion+=10
    It does solve most of the problems around here yeah!
 * mistype
   ~suspicion+=10
   I swear to god, drunk people....
   
- Did you hear about the new tax forms that came down from accounting?
- It was Jerry's idea and so far it's only given me more work.
- Only today 3 people called because they broke their keyboards out of frustration.
 * More work 
    ~suspicion+=15
    Wow are we insinuating we are lazy?! 
    I'll have you know we have the biggest worload of all the departments
 * 403K-CT5 form?
    ~suspicion-=10
    Hm actually, its called the 403k-CL5 form, but close enough!
 * mistype
   ~suspicion+=10
   You are making no sense....

- Oh, Benedict is walking over...
- Gotta run... 
- He requested I updated all the setups on the marketing floor by end of week, we haven't even started yet... 
- See ya around
    
//-----------------------Char change-----------------------
~character=Tim

- Heeey man -hic- how you doin?
 * You good?
    ~suspicion-=5
    Yeah man, I'm greaa-hic-aat!
 * Heeey!
    Ehehe hey... do you know where my nephew went? 
    I was s'posed to drive him to some place called fortnite?
 * Want water?
    ~suspicion+=10
    Water?! Are you crazy? 
    Everyone knows I only drink buckfast!
 * Sit?
    Nah man, I've got to danceee! 
    I can feel the music in my bones!
 * mistype
   ~suspicion+=10
   I don't know who's drunker, you or me!
    
- Hmmm, what floor you on? Don't think I've seen your face before...
 * None 
    ~suspicion-=5
    Oh so you don't work here?
    Good, finally someone I can relate to!
 * I don't know
    ~suspicion-=5
    I get you! This building is so big it's easy to get lost.
 * Yours
    I'm so sorry, I didn't mean to be rude, I'm not good with faces.
 * mistype
   ~suspicion+=10
   You are making no sense....

- So, how are you enjoying the free food and open bar?
 * Great!
    ~suspicion-=5
    Free food always tastes the best!
 * No quiche
    ~suspicion-=10
    Oh shoot! I was supposed to get the quiche...
 * Needs more wine!
    ~suspicion-=5
    Right?
    I swear there was more wine there before I drank it.
 * mistype
   ~suspicion+=10
   You're wilding right now...

- Oh no!
- My cup is empty again, how does this keep happening? 
- Bye!

//-----------------------Char change-----------------------
~character=Benedict

- You look lost son.
- Do you even know what we make here at Redundant Solutions?

 * Arrogance?
    ~suspicion-=5
    Ha! You've got guts boy, I like that. 
    Speak to Miss Philips, tell her to bring you along on my next Ayahuasca retreat.
 * Widgets?
    ~suspicion-=10
    That's right, the best damn widgets in the world, and don't you forget it
 * Photocopiers?
    ~suspicion+=25
    What are you talking about! 
    We make widgets you idiot! 
    Get out of my sight, before I fire you!   

- Wait a second, I have to get this call - YEA MIKE? 
- I HOPE YOU'RE NOT CALLING ME ABOUT THE CONFERENCE ROOMS AGAIN! 
- FIGURE IT OUT OR YOU'RE FIRED! - so, how you enjoying life here at our little slice of heaven?
 * Good food
    ~suspicion-=5
    I know right? Only the best for our collaborators. 
    After all, WE deserve it.
 * Amazing
    ~suspicion-=10
    I thought so, we are a tight knit family here at Redudant Solutions.
 * Sucks ass
    ~suspicion+=20
    Woah there friend! 
    We do endorse brutal honesty, but you should watch your mouth when talking to me.
 * mistype
   ~suspicion+=10
   Whoa friend, pronounce your words!
   
- Yeah we on the front end of widget development and- oh phone's ringing again, one second.
- HELLO? YES! GET IT DONE BY 8 I DON'T GIVE A RAT'S ASS ABOUT LAME EXCUSES! BYE!
- Sorry, that was my wife, where were we?
 * Jesus...
    ~suspicion-=5
    Oh don't worry about it, we embrace all religions and walks of life here at Redundant Solutions.
 * Divorce
    ~suspicion+=15
    No no, happily married, 8 years now. 
    You know, lovely woman, love of my life, all that mumbo jumbo.
 * Relationship goals
    ~suspicion-=10
    I know right? 
    I endorse all our collaborators to have healty relationships!
    Communication is KEY, my good sir
 * mistype
    ~suspicion+=10
    Whoa friend, pronounce your words!

- Alas, this was a lovely chitchat, I have to go find my son.
- He keeps trying to install some computer game on our work stations. 
- Enjoy the party!

//-----------------------Char change-----------------------
~character=Jimmy

- I can't believe this sandwich theft keeps happening! I'll have to write an email to HR again, ugh...
 * What's up?
    ~suspicion+=10
    What do you mean what's up?! We have a very serious problem of sandwich thievery!
 * Maybe Tim? 
    Do you think he's behind this?! He does have little rat thief hands...
 * Justice!
    ~suspicion-=10
    Yes! I demand the culprit be brought to justice!
 * mistype
    ~suspicion+=10
    Whoa friend, slow down, didn't understand.

- Can you believe Margaret from HR told me, it wasn't that big of a deal?
- She's crazy!
 * Overreacting
    ~suspicion+=25
    Overreacting?! I'm not overreacting! 
    It's much more than that! 
    You don't take a man's sandwich like that!
 * Tim?
    ~suspicion-=5
    Yeah! I think I WILL ask Tim, mighteven smell his breath, see if it smells like turkey
 * Crazy
    ~suspicion-=10
    Finally, someone that agrees with me! We deserve to be heard!
 * mistype
    ~suspicion+=10
    Whoa friend, slow down, didn't understand.

- They really thought having turkey mini quiches here would distract me from what really matters! Fools!
 * Mini quiches?
    Oh, I've eaten the last 20, my bad...
 * It matters?
    ~suspicion+=10
    We've been over this! You don't play with a man's food!
 * Corruption!
    ~suspicion-=10
    You're right! 
    They think we can't fight back against this oppressive system!
    This goes all the way to the top!
 * Turkey sucks!
    ~suspicion+=11
    Blasphemy! I'll make a complaint to HR about this!
 * mistype
    ~suspicion+=10
    Whoa friend, slow down, didn't understand.

- Don't be fooled, they're only having this party to keep us quiet about our fridge rights! I'm going to go find someone from HR!

//-----------------------Char change-----------------------
~character=Miriam

- And who might you be? I know everyone in this company.
 * Tim hired me?
    ~suspicion+=15
    He's a moron, but I don't think he would hire someone without consulting me first!
 * Gile's Driver
    ~suspicion+=5
    My brother finally caved and hired a personal driver for the brat?
    Seems unlikely...
 * Janitor
    I see! Well I don't really know the whole janitorial services team...
 * Intern?
    ~suspicion+=25
    Are you asking me if you're an intern here? 
    That's definitely a bad way to about it.
 * Catering
    ~suspicion+=5
    Without a uniform? What firm did we hire?~
 * mistype
    ~suspicion+=10
    You can't even talk straight!
    
- So, how are you finding the company? 
- We do try to have some get togethers every once in a while to promote workplace socializing.
 * It's ok...
    ~suspicion+=5
    Only ok? i see you think we might have room for improvements.
 * Was shit frankly
    ~suspicion+=25
    Oh my word. No need for that type of language in the work place! 
    We are only acceting constructive criticism at the moment.
 * Amazing
    ~suspicion-=10
    Happy to hear it! 
    Please do make sure to talk to your colleagues about how great it was.
    We keep getting negative reviews in the anonimous suggestion box.

- Ugh, can you believe Tim?
- He is completely wasted!
- Can't believe he's top pick for the annual bonus! 
- He hardly does any work.
 * Bitchy
    ~suspicion+=25
    Whoa whoa whoa! HR WILL be hearing about this, you can be sure!
 * Unfair
     ~suspicion-=10
    Completely unfair!
    Not saying I'M the one that should be getting it, but there certainly are more deserving candidates.

- I'm keeping my eye on you!

=== fail ===
~suspicion+=11
- I don't think you work here at all! I'm calling secuirty.

-> END
