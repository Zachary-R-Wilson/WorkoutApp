import { StyleSheet, Text, View, Pressable, ScrollView } from "react-native";
import { Button } from "@/components/Button";
import MaterialIcons from '@expo/vector-icons/MaterialIcons';
import { Separator } from "@/components/Separator";


export function WorkoutSelector({ workoutName, dayName, openDrawer, setDrawerContent }: { workoutName: string, dayName: string, 
openDrawer: () => void, setDrawerContent: (element: JSX.Element) => void }) {
	const selectDayContent: JSX.Element = 
	(<ScrollView style={{width: "90%"}}>
			<Button
				label="Push"
			/>
			<Button
				label="Pull"
			/>
			<Button
				label="Legs"
			/>
	</ScrollView>);

	const editWorkoutContent: JSX.Element = 
	(<ScrollView style={{width: "90%"}}>
			
	</ScrollView>);
	
	const handleSelectDayOpenDrawer = () => {
		setDrawerContent(selectDayContent);
		openDrawer();
	};

	const handleEditWorkoutOpenDrawer = () => {
		setDrawerContent(editWorkoutContent);
		openDrawer();
	};

  return (
		<View style={styles.container}>
			<View style={styles.workoutContainter}>
				<Text style={styles.workoutTitle}>{workoutName}</Text>
				<Pressable style={styles.icon}
					onPress={handleEditWorkoutOpenDrawer}
				>
					<MaterialIcons name="more-horiz" size={37} color="#CCF6FF" />
				</Pressable>
			</View>

      		<Separator />

			<View style={styles.dayContainter}>
				<Text style={styles.text}>{dayName}</Text>

				<Button
					label="Step Into It"
				/>

				<Button
					label="Select Day"
				/>

			</View>
		</View>
  );
}

const styles = StyleSheet.create({
	container: {
		justifyContent: "center",
		alignItems: "center",
		backgroundColor: "#EB9928",
		borderColor: "#CCF6FF",
		borderWidth: 1,
		borderRadius: 5,
		margin:10
	},

	workoutContainter: {
		flexDirection: "row",
		alignItems: "center",
		justifyContent:"center",
		position: 'relative',
		width:"100%"
	},

	dayContainter: {
		justifyContent: "space-between",
		width: "90%",
		gap: 10,
		marginBottom: 10,
	},

	workoutTitle: {
		fontSize: 30,
		fontWeight:"bold",
		color: '#2F4858',
	},

	icon: {
		position: 'absolute',
		right: 0,
		margin:10,
	},

	text: {
		fontSize: 30,
		color: '#2F4858',
		alignSelf: "center",
	},
});