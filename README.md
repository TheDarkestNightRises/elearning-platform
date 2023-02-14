# E-learningApp
A E-learning application as a heterogeneous distribute system written in c# and java and using Blazor for the UI, mySQL for database and Web API/gRPC as middlewares. Available in multiple langauges where students all over Europe can get access to free and high quality study materials.
<br>
[Documentation.pdf](https://github.com/Andrei-Lichi/E-learningApp/files/10439966/ProjectAndProcessReport.pdf)
<br>
[Appendices.zip](https://github.com/Andrei-Lichi/E-learningApp/files/10439965/Appendices.zip)


## Features

- Registering and Logging (as a teacher, student or moderator)
- Ask a question
- Post a lecture
- Upvote lectures
- Profile
- Delete/Edit lectures/questions
- Comment on lectures/questions


## Tech Stack(3-tier architecture)


**Tier1(User interface):** Blazor, Html, C#  (connected to the second tier through Web APIs

**Tier2(Application Tier):** C# (connected to the third tier thorugh gRPC)

**Tier3(Data tier):** Java, mySQL (the connection with the database is made with JPA rapository)


## Lessons Learned

While developing this project, we gained knowledge about distributed systems and working with Maven.<br>
We also got introduced to middlewares which we used during the implementation phase.

## Demo

https://www.youtube.com/watch?v=ZsazwxjM_p8


## Authors

- [@TheDarkestNightRises](https://github.com/TheDarkestNightRises/)
- [@Andrei-Lichi](https://github.com/Andrei-Lichi/)
- [@Cosmin-Teodoru](https://github.com/Cosmin-Teodoru/)
- [@kotruta123](https://github.com/kotruta123)
- [@Oriana11](https://github.com/Oriana11)
## Feedback

If you have any feedback, please reach out to us.
