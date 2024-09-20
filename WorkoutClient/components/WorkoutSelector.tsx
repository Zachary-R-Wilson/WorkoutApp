import { StyleSheet, Text, View, Button} from "react-native";

export function WorkoutSelector() {
	const Separator = () => <View style={styles.separator} />;

  return (
		<View style={styles.container}>
			<View style={{ justifyContent: "center", alignItems: "center",}}>
				<Text style={styles.text}>Workout Name</Text>
			</View>
      <Separator />
			<View>
				<Text style={styles.text}>Day Name</Text>
				<Button
					onPress={() => {console.log("Start Workout Button Pressed!")}}
					title="Step Into It"
					color="#CCF6FF"
					/>
				<Button
					onPress={() => {console.log("Select Dat Button Pressed!")}}
					title="Select Day"
					color="#CCF6FF"/>
			</View>
		</View>
  );
}

const styles = StyleSheet.create({
	container:{
		// margin: 10,
		justifyContent: "center",
    alignItems: "center",
		backgroundColor: "#EB9928",
		borderColor: "#CCF6FF",
		borderWidth: 1,
		borderRadius: 5,
	},
  text: {
    fontSize: 30,
    color: '#2F4858',
  },
	separator: {
    // marginVertical: 8,
    borderBottomColor: '#737373',
    borderBottomWidth: 10,
  },
});