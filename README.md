# Z-MAN Workout App
Z-MAN Workout App is an open-source full-stack application designed for gym environments. It aims to simplify the process of creating and tracking workouts while offering advanced features such as workout analysis. The application serves as a demonstration of the engineering skills I developed during my time at Kansas State University and through various internship experiences. It is built using React Native for the front-end interface and integrates with a C# API for efficient user data storage and retrieval.

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
