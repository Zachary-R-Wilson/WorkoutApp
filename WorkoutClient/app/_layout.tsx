import { Stack } from "expo-router";

export default function RootLayout() {
  return (
    <Stack
      screenOptions={{
        headerShown: false,
      }}>
      <Stack.Screen name="index" />
      <Stack.Screen name="signup" />
      <Stack.Screen name="workouts" />
      <Stack.Screen name="newWorkout" />
      <Stack.Screen name="newDay" />
      <Stack.Screen name="newExercise" />
      <Stack.Screen name="maxes" />
    </Stack>
  );
}
