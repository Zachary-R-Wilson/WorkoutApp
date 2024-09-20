import { StyleSheet, View, ScrollView } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { BottomNav } from "@/components/BottomNav";
import { WorkoutSelector } from "@/components/WorkoutSelector";

const Separator = () => <View style={styles.separator} />;

export default function Index() {
  return (
    <SafeAreaView style={styles.container}>
      <Header />
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

	separator: {
		borderBottomColor: '#CCF6FF',
		borderBottomWidth: 1,
		width: "100%",
		marginVertical: 10,
	},
});