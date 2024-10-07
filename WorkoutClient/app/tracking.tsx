import { useEffect } from "react";
import { StyleSheet, View, Text } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { GestureHandlerRootView, Swipeable } from 'react-native-gesture-handler';
import { TrackingBody } from "@/components/TrackingBody";
import { BottomNav } from "@/components/BottomNav";
import { Separator } from "@/components/Separator";
import { BottomDrawer } from "@/components/BottomDrawer";
import useBottomDrawer from '@/hooks/useBottomDrawer';

export default function Tracking()  { 
  const { isVisible, content, openDrawer, closeDrawer, setDrawerContent } = useBottomDrawer();

  useEffect(() => {

  }, []);


  const renderLeftActions = () => {
    return (
      <View style={{ backgroundColor: 'red', justifyContent: 'center', flex: 1 }}>
        <Text style={{ color: 'white', padding: 10 }}>Delete</Text>
      </View>
    );
  };

  const renderRightActions = () => {
    return (
      <View style={{ backgroundColor: 'green', justifyContent: 'center', flex: 1 }}>
        <Text style={{ color: 'white', padding: 10 }}>Right!!</Text>
      </View>
    );
  };

  return (
    <SafeAreaView style={styles.container}>
      
      <TrackingBody 
            workoutName="Leg Day!"
          />
          
      {/* <GestureHandlerRootView style={{flex: 2}}>
        <Swipeable renderLeftActions={renderLeftActions} renderRightActions={renderRightActions}>
          <TrackingBody 
            workoutName="Leg Day!"
          />
        </Swipeable>
      </GestureHandlerRootView> */}
      
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