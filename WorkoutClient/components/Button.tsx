import { StyleSheet, Text, View, Pressable} from "react-native";
import { useNavigation } from '@react-navigation/native';

export function Button({ route, label }: { route: string, label: string }) {
	const navigation = useNavigation();
  
	return (
	<Pressable
		// onPress={() => navigation.navigate(route)}
	>
		<View style={styles.container}>
			<Text style={styles.text}>{label}</Text>
		</View>
	</Pressable>	
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