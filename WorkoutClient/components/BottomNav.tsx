import { StyleSheet, View, Pressable} from "react-native";
import MaterialIcons from '@expo/vector-icons/MaterialIcons';
import { useRouter } from 'expo-router';


export function BottomNav() {
  const router = useRouter();

  return (
    <View style={styles.container}>
        <Pressable
          onPress={() => {
            router.push('/workouts');
          }}>
            <MaterialIcons name="fitness-center" size={58} color="#CCF6FF" />
        </Pressable>

        <Pressable
          onPress={() => {
            router.push('/');
          }}>
            <MaterialIcons name="add-circle-outline" size={58} color="#CCF6FF" />
        </Pressable>

        <Pressable
          onPress={() => {
            router.push('/');
          }}>
          <MaterialIcons name="manage-accounts" size={58} color="#CCF6FF" />
        </Pressable>
    </View>
  );
}

const styles = StyleSheet.create({
	container:{
    width: "100%",
		justifyContent: "space-around",
    alignItems: "center",
    flexDirection: "row",
	}
});