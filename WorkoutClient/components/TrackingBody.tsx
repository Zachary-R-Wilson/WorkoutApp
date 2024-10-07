import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, ScrollView, TextInput } from "react-native";
import { Header } from "@/components/Header";
import { Separator } from "@/components/Separator";

interface Days {
  [key: string]: string;
}

export function TrackingBody({ workoutName, } : { workoutName: string, }) {
	const [reps, setReps] = useState('');
  const [weight, setWeight] = useState('');
  const [rpe, setRpe] = useState('');

  return (
		<ScrollView style={styles.workoutScroll}>
			<Header title = {workoutName} />
      <Separator />     

			<View style={styles.container} >
				<Text style={styles.workoutTitle}>{"Squats"}</Text>
				<Separator />

				<View style={styles.infoContainter}>
					<Text style={styles.text}>{"For: 3 sets"}</Text>
					<Text style={styles.text}>{"Rep Range: 4-5"}</Text>
				</View>
			</View>

			<View style={styles.container} >
				<Text style={styles.workoutTitle}>Last Week</Text>
				<Separator />

				<View style={styles.infoContainter}>
					<Text style={styles.text}>{"Total Reps: 12"}</Text>
					<Text style={styles.text}>{"Weight: 275"}</Text>
					<Text style={styles.text}>{"RPE: 8"}</Text>
				</View>
			</View>

			<View style={styles.container} >
				<Text style={styles.workoutTitle}>Today</Text>
				<Separator />

				<View style={styles.DataContainter}>
					<View style={{justifyContent:"flex-start"}}>
						<Text style={styles.text}>{"Total Reps:"}</Text>
						<Text style={styles.text}>{"Weight:"}</Text>
						<Text style={styles.text}>{"RPE:"}</Text>
					</View>
					<View>
						<TextInput style={styles.textInput} inputMode="numeric"  
							onChangeText={(value) => {
								if (/^\d*$/.test(value)) setReps(value);
							}}
							value={reps}>
						</TextInput>
						<TextInput style={styles.textInput} inputMode="numeric"  
						onChangeText={(value) => {
							if (/^\d*$/.test(value)) setWeight(value);
						}}
						value={weight}>
						</TextInput>
						<TextInput style={styles.textInput} inputMode="numeric" 
							onChangeText={(value) => {
								if (/^\d*$/.test(value)) setRpe(value);
							}}
							value={rpe}>
						</TextInput>
					</View>					
				</View>
			</View>
    </ScrollView>
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

  workoutScroll: {
    flex: 1,
  },

	infoContainter: {
		justifyContent: "space-between",
		width: "90%",
		marginBottom: 10,
	},

	DataContainter: {
		flexDirection: "row",
		justifyContent: "space-between",
		width: "90%",
		marginBottom: 10,
	},

	workoutTitle: {
		fontSize: 30,
		fontWeight:"bold",
		color: '#2F4858',
	},

	text: {
		fontSize: 30,
		color: '#2F4858',
		alignSelf: "center",
	},

	textInput: {
		width:"50%",
		borderWidth: 1,
		borderRadius: 5,
    backgroundColor: "#CCF6FF",
		borderColor: "#FFFFFF",
    height: 35,
    textAlign:"center",
    fontSize:25,
    color:"#2F4858",
    
		marginVertical:5,
	},
});