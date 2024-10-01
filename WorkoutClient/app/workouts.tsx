import { StyleSheet, ScrollView, Pressable } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { BottomNav } from "@/components/BottomNav";
import { WorkoutSelector } from "@/components/WorkoutSelector";
import { Separator } from "@/components/Separator";
import { BottomDrawer } from "@/components/BottomDrawer";
import useBottomDrawer from '@/hooks/useBottomDrawer';


export default function Workouts() { 
  const { isVisible, content, openDrawer, closeDrawer, setDrawerContent } = useBottomDrawer();
  return (
    <SafeAreaView style={styles.container}>
      <Header title = "Looking Strong Today, Zach!" />
      <Separator />     

      <ScrollView style={styles.workoutScroll}>
        <WorkoutSelector workoutName="Push, Pull, Legs" dayName="Leg Day" openDrawer={openDrawer} setDrawerContent={setDrawerContent} />
      </ScrollView>

      <Separator />
      <BottomNav openDrawer={openDrawer} setDrawerContent={setDrawerContent} />

      <BottomDrawer content={content} isVisible={isVisible} closeDrawer={closeDrawer}/>
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