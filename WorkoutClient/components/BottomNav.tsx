import { StyleSheet, View, Pressable} from "react-native";
import MaterialIcons from '@expo/vector-icons/MaterialIcons';

export function BottomNav() {
  return (
    <View style={styles.container}>
        <Pressable>
          <MaterialIcons name="fitness-center" size={58} color="#CCF6FF" />
        </Pressable>
        <Pressable>
          <MaterialIcons name="add-circle-outline" size={58} color="#CCF6FF" />
        </Pressable>
        <Pressable>
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