import { StyleSheet, View } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { BottomNav } from "@/components/BottomNav";
import { WorkoutSelector } from "@/components/WorkoutSelector";

const Separator = () => <View style={styles.separator} />;

export default function Index() {
  return (
    <SafeAreaView style={styles.container}>
      <SafeAreaView style={styles.header}>
        <Header />
      </SafeAreaView>

      <Separator />

      {/* needs to be scrollable field */}
      <View style={styles.workoutView}>
        <WorkoutSelector />
      </View>

      <Separator />

      <SafeAreaView style={styles.bottomNav}>
        <BottomNav />
      </SafeAreaView>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: "#2F4858",
    flex: 1,
    padding: 20,
    justifyContent: "center",
    alignItems: "center",
  },

  workoutView: {
    width: "100%",
  },

  header: {
    position: "absolute",
    top: 0,
  },

  bottomNav: {
    position: "absolute",
    bottom: 0,
  },

  separator: {
    borderBottomColor: '#737373',
    borderBottomWidth: 10,
  },
});