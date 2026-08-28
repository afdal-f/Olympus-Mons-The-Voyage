# Olympus Mons: The Voyage

<img width="630" height="500" alt="image" src="https://github.com/user-attachments/assets/86628e5e-b032-4d12-93b4-5aad02f3ca4c" />

Have you ever wanted to drive in a place that is out of this world? Olympus Mons is the **biggest** mountain in the Solar System, and I have turned **REAL MOLA SATELLITE DATA** into a terrain so that you can finally feel what it feels like to drive in a place literally out of this world.

## Quick Summary (if you are skimming)

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/588a2a50-bc26-4f1f-9996-d55617b82992" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/e28d0bc7-ba43-431a-aaa6-1a5b86e11b80" />


* This is a game where you can experience driving on the **biggest mountain in the Solar System**, Olympus Mons.
* The mountain is made using **REAL NASA MOLA Data**; absolutely no part of the mountain model was made by estimations or artistic impressions.
* You have to drive a rover through a few checkpoints and then find out how much time you took to the final point.

## The goal of this game

Have you ever wondered **how another planet feels like**? What is driving on Mars like? The goal of the game is to **answer exactly that**.

## Scientific Accuracy

* My goal was not to make the mountain look like Olympus Mons; it was to **get Olympus Mons itself into a playable simulator** by all means necessary.
* The game **prioritizes** scientific accuracy; gravity is set to 3.71, the mountain uses real satellite data, etc.
* One thing that may not be as scientifically accurate is probably the **landforms**, because I had to accept that adding specific Martian landforms was too time-intensive to study and build; the rock spawning itself was one of the biggest **headaches**.

## The star of the show

* Olympus Mons is the **biggest mountain in the Solar System**, and is a HUGE **shield volcano**.
* It is approximately **20 km tall**. What people fail to talk about a lot, which I think is absolutely mind-blowing, is the fact that it is **600 km wide**. That means it is about as wide as Los Angeles to San Francisco, or London to Paris. If you start driving a rover at a constant 60 km/h, it will take **almost 10 hours, ignoring breaks**.
* It is so big that from orbit you would not see a mountain but a **HUGE raised area 600 km in diameter**.

## About the NASA MOLA Data

* I specifically made sure that the mountain model was as scientifically accurate as possible.
* First, I had to figure out where I can get the MOLA DEM (DEM stands for Digital Elevation Model). This specific part was honestly way more harder than I had expected; I had to search through a lot of websites and finally found this **USGS Astrogeology website**.
* From there, I had to make a **"job" application** where I got a little grayscale picture, which was the **DEM**. I imported it **into Blender** and got a Plane to turn **into Olympus Mons.**

## How the game was made

* Before development, I began studying Unity and Blender; it went on like this for **2 weeks** or so. I was studying Unity from **Unity Learn** because I just couldn't get myself to watch YouTube tutorials, and honestly, Unity Learn does teach pretty well!
* I watched a bit of the Donut tutorial from the **infamous Blender Guru**, and then watched a bit of **Grant Abitt's** tutorials. After that, I had to get the mountain model. The Olympus Model was made using **real NASA MOLA data**.
* The model was imported into the game, and then the physics phase began. I changed the gravity to be more Mars-like and then had a lot of trouble with the wheels, but it all worked out at the end.
* Then the designing phase came; I had to **learn UI from scratch**, and for some reason, it was very hard. Mostly because Unity UI **wasn't as straightforward as I was expecting**.
* After that, I began work on the most annoying part of it, **Particle Effects**. First, I made dust devils, then dust storms, then clouds. It sounds fast-paced when I say it, but in reality, each took about **3–4 days each** because I was very new to Unity and had to figure out a lot of things by myself.
* I did kinda give up on the rock spawning because, after my script started to work but was **extremely laggy**, I had no other choice but to use **Claude to rewrite it**.
* After that, it was way more straightforward; I got the music to work, added credits, improved UI, etc., etc., and then **made my first ship**.
* The second ship is just the first ship but with WAY better optimization and a settings feature.

## Why I made the game

Mars, in my opinion, is one of the **most beautiful planets** in our Solar System; it's so **simple yet breathtaking**. From the blue sunsets to the starry nights to the orange daytime to the dust storms to the beautiful land structures. Olympus Mons stands as a **highlight**; it is the biggest mountain in the Solar System.

## Challenges I faced:

* Rock Spawning was extremely hard; I spent **almost a week** trying to figure it out. It came to a point where my ideas were at such a low that I had to take out a **physical notebook** and *attempt* to try and sketch out the logic physically. It **did NOT work**.

* Blender was very confusing. Blender Guru was nice and all, but I barely could remember anything from when I watched the video (which at the time was an hour ago or so). Blender is **WAY too packed with features**; I mean, how are we supposed to keep count of them? My initial rover prototype looked like a **genuine duck**.

* Finding the DEM heightmaps itself **was a headache**; every website was either a preview or talking about a completely different planet, but I finally got it. Thank you, **USGS**! I have no idea whether you are a government body or private, but whatsoever, they saved me.

* Learning Unity from Scratch was **not that hard**, but I had to do it in a **tight time frame while simultaneously creating an intermediate project**, so that was kinda hard.

* Rover Physics was not the hardest, but I think it **probably was the most time-consuming**; the wheels were NOT functioning, and once I got them to function, I had to face suspension and damper, which was a headache too. The rover stability is **slightly increased** in the last ship but still annoying.

## Things I had learnt:

* Unity, completely **from scratch**.

* Game development is **NOT easy**; you **CANNOT make Forza Horizon 5 in a month** or so as an indie dev.

* Visual Studio was probably a better fit for my potato; **CLion EATS RAM** (This might sound irrelevant, but for my more long-term project of getting good at C++, this project helped me realize how beautiful Visual Studio is).

* C#, this was **relatively easy** because I already have experience in C++, which I was learning at the time of starting the game.

* Blender, this was a **very specific headache**, and I absolutely hated it, and I **do NOT see any more projects** in the near future of me using Blender, but I wouldn't say it was completely useless.

## Technical Features:

* A Scientifically accurate Olympus Mons 3D Model

* Mars-like gravity

* Strong particle system usage

* Moving and dynamic clouds

* Dynamic dust storms that strongly interact with the Rover

* Easy volume management from settings

* Credits scene available from in-game menu and main menu

* Strong main menu and in-game menu

* Strong Red-Brown and Mars theme

* Online Leaderboard

* Checkpoint System

* Time tracker

* **Performance Optimization** for lower-end devices (like mine lol)

* Occasional Dust Devil

* Large Scale Rock Spawning with Render Distance

## What makes this project different

Most Space exploration projects produce **generic-looking planets** with absolutely nothing special about them that applies to real life. We get planets humanity will probably never step in. Till now, there is no Sci-fi game that **gives** you the feeling of driving through an **actual terrain that you know exists** exactly as what you are seeing on your screen somewhere near the Earth. It produces an urge to want to get to outer space, explore it, marvel at its beauty, etc., etc. What I'm trying to say is, a space exploration **game with a similar goal is uncommon**.
