import { StyleSheet, Text, View, Pressable} from "react-native";

export function Button({ label }: { label: string }) {
	return (
		<View style={styles.container}>
			<Text style={styles.text}>{label}</Text>
		</View>
  );
}

const styles = StyleSheet.create({
	container:{
		justifyContent: "center",
		alignItems: "center",
		backgroundColor: "#CCF6FF",
		borderColor: "#FFFFFF",
		borderWidth: 1,
		borderRadius: 5,
		height: 40,
	},

	text: {
		fontSize: 25,
		color: '#2F4858',
	},
});