import { useEffect, useState } from "react";
import { StyleSheet, View, FlatList, Dimensions, ViewToken } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { TrackingBody } from "@/components/TrackingBody";
import { BottomNav } from "@/components/BottomNav";
import { Separator } from "@/components/Separator";
import { BottomDrawer } from "@/components/BottomDrawer";
import useBottomDrawer from '@/hooks/useBottomDrawer';
import { Header } from "@/components/Header";
import { Button } from "@/components/Button";

const { width } = Dimensions.get('window');
const ITEM_WIDTH = width * .9;

export default function Tracking()  { 
  const { isVisible, content, openDrawer, closeDrawer, setDrawerContent } = useBottomDrawer();

  useEffect(() => {

  }, []);

  const exercises = [
    {
      exerciseName: "Leg Press",
      sets: 3,
      repRange: "8-10",
      lastReps: 30,
      lastWeight: 416,
      lastRpe: 8,
    },
    {
      exerciseName: "Squats",
      sets: 3,
      repRange: "4-5",
      lastReps: 12,
      lastWeight: 275,
      lastRpe: 8,
    },
    {
      exerciseName: "RDL",
      sets: 3,
      repRange: "8-10",
      lastReps: 30,
      lastWeight: 65,
      lastRpe: 8,
    }
  ];

  const [currentIndex, setCurrentIndex] = useState(0);

  const handleViewableItemsChanged = ({ viewableItems }: { viewableItems: ViewToken[] }) => {
    if (viewableItems.length > 0) {
      const index = viewableItems[0].index;
      setCurrentIndex(index !== null ? index : 0);
    }
  };

  const viewabilityConfig = {
    viewAreaCoveragePercentThreshold: 50,
  };

  return (
    <SafeAreaView style={styles.container}>
      <Header title = {"workoutName"} />
      <Separator />

      <View style={{ flex: 2 }}>
        <FlatList
          data={exercises}
          horizontal
          pagingEnabled
          keyExtractor={(item, index) => index.toString()}
          showsHorizontalScrollIndicator={false}
          onViewableItemsChanged={handleViewableItemsChanged}
          viewabilityConfig={viewabilityConfig}
          renderItem={({ item }) => (
            <View style={styles.itemContainer}>
              <TrackingBody
                exerciseName={item.exerciseName}
                sets={item.sets}
                repRange={item.repRange}
                lastReps={item.lastReps}
                lastWeight={item.lastWeight}
                lastRpe={item.lastRpe}
              />
            </View>
          )}
        />
      </View>


      <View style={styles.subcontainer}>
        <View style={{ width: "90%", marginVertical: 5}}>
          <Button 
            label="Complete Workout"
            pressFunc={() => {}}
          />
        </View>
      </View>

      
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

  subcontainer: {
    width: "90%",
		justifyContent: "center",
		alignItems: "center",
		backgroundColor: "#EB9928",
		borderColor: "#CCF6FF",
		borderWidth: 1,
		borderRadius: 5,
    alignSelf:"center",
	},

  itemContainer: {
    width: ITEM_WIDTH,
    justifyContent: 'center',
    alignItems: 'center',
  },

  workoutView: {
    width: "100%",
  },
});