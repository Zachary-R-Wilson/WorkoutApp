# WorkoutApp
This Project is an open-source app to be used in the gym. The app sets out to streamline the process of creating and tracking workouts, with additional features such as a workout analysis.
This project is meant to showcase engineering skills that I have learned during my time at Kansas State University.


# About
This is a Full Stack Application that uses the following Tools and programs:
* ReactNative
* Expo
* C#
* SQL (SSMS)


# Set Up & Running The Project
To set up the project, you will need the Docker Engine as well as Expo.

* Configure the .env before running the container. Open the ```example.env``` and change the passwords/key, then rename the file to ```.env```
* After the .env is created, run the Docker-Compose: ```Docker-Compose up --build```
* Once the Container is running, you can run the ```InitDatabase.ps1``` to initalize the database.

Now the backend should be running locally.
To run the Frontend, go to the WorkoutClient folder and run: ```npx expo start```
