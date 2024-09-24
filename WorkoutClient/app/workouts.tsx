import { StyleSheet, ScrollView } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { BottomNav } from "@/components/BottomNav";
import { WorkoutSelector } from "@/components/WorkoutSelector";
import { Separator } from "@/components/Separator";

export default function Workouts() {
  return (
    <SafeAreaView style={styles.container}>
      <Header title = "Looking Strong Today, Zach!" />
      <Separator />     

      <ScrollView style={styles.workoutScroll}>
        <WorkoutSelector workoutName="Push, Pull, Legs" dayName="Leg Day" />
        <WorkoutSelector workoutName="Push, Pull, Legs" dayName="Leg Day" />
        <WorkoutSelector workoutName="Push, Pull, Legs" dayName="Leg Day" />
      </ScrollView>

      <Separator />
      <BottomNav />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 20,
    flex: 1,
    backgroundColor: "#2F4858",
  },

  workoutScroll: {
    flex: 1,
  },

  workoutView: {
    width: "100%",
  },
});