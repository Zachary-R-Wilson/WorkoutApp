import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, ScrollView, TextInput } from "react-native";
import { Separator } from "@/components/Separator";

interface Days {
  [key: string]: string;
}

export function TrackingBody({ exerciseName, sets, repRange, lastReps, lastWeight, lastRpe } : { exerciseName: string, sets: number, repRange: string, lastReps: number, lastWeight: number, lastRpe: number }) {
	const [reps, setReps] = useState('');
  const [weight, setWeight] = useState('');
  const [rpe, setRpe] = useState('');

  return (
		<ScrollView style={styles.workoutScroll}>
 			<View style={styles.container} >
				<Text style={styles.workoutTitle}>{exerciseName}</Text>
				<Separator />
				
				<View style={styles.infoContainter}>
					<Text style={styles.text}>{`For: ${sets} sets`}</Text>
					<Text style={styles.text}>{`Rep Range: ${repRange}`}</Text>
				</View>
			</View>

			<View style={styles.container} >
				<Text style={styles.workoutTitle}>Last Week</Text>
				<Separator />

				<View style={styles.infoContainter}>
					<Text style={styles.text}>{`Total Reps: ${lastReps}`}</Text>
					<Text style={styles.text}>{`Weight: ${lastWeight}`}</Text>
					<Text style={styles.text}>{`RPE: ${lastRpe}`}</Text>
				</View>
			</View>

			<View style={styles.container} >
				<Text style={styles.workoutTitle}>Today</Text>
				<Separator />

				<View style={styles.DataContainter}>
					<View >
						<Text style={styles.text}>{"Total Reps:"}</Text>
						<Text style={styles.text}>{"Weight:"}</Text>
						<Text style={styles.text}>{"RPE:"}</Text>
					</View>
					<View style={{ marginLeft: 15}}>
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