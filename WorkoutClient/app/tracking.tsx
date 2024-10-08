import { useEffect } from "react";
import { StyleSheet } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { GestureHandlerRootView, Swipeable } from 'react-native-gesture-handler';
import { TrackingBody } from "@/components/TrackingBody";
import { BottomNav } from "@/components/BottomNav";
import { Separator } from "@/components/Separator";
import { BottomDrawer } from "@/components/BottomDrawer";
import useBottomDrawer from '@/hooks/useBottomDrawer';
import { Header } from "@/components/Header";

export default function Tracking()  { 
  const { isVisible, content, openDrawer, closeDrawer, setDrawerContent } = useBottomDrawer();

  useEffect(() => {

  }, []);


  const renderLeftActions = () => {
    return (
      <TrackingBody 
          exerciseName = "Squats"
          sets = {3}
          repRange = "4-5"
          lastReps = {12}
          lastWeight = {275}
          lastRpe = {8}
          />
    );
  };

  const renderRightActions = () => {
    return (
      <TrackingBody 
          exerciseName = "RDL"
          sets = {3}
          repRange = "8-10"
          lastReps = {30}
          lastWeight = {65}
          lastRpe = {8}
          />
    );
  };

  return (
    <SafeAreaView style={styles.container}>
      <Header title = {"workoutName"} />
      <Separator />  
      <GestureHandlerRootView style={{flex: 2}}>
        <Swipeable renderLeftActions={renderLeftActions} renderRightActions={renderRightActions}>
          <TrackingBody 
            exerciseName = "Leg Press"
            sets = {3}
            repRange = "8-10"
            lastReps = {30}
            lastWeight = {416}
            lastRpe = {8}
            />
        </Swipeable>
      </GestureHandlerRootView>
      
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

  workoutView: {
    width: "100%",
  },
});