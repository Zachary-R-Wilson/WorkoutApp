import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, ScrollView, TextInput } from "react-native";
import { Separator } from "@/components/Separator";

interface Days {
  [key: string]: string;
}

interface TrackingInfo {
  date: string;
  weight?: string;
  completedReps?: number;
  rpe?: number;
  exerciseKey: string;
}

export function TrackingBody({ exerciseKey, exerciseName, sets, repRange, lastReps, lastWeight, lastRpe, trackingInfo, updateTrackingModel } : { exerciseKey:string, exerciseName: string, sets: number, repRange: string, lastReps: string, lastWeight: string, lastRpe: string, trackingInfo:TrackingInfo, updateTrackingModel:(exerciseName: string, updatedInfo: TrackingInfo)=>void }) {
	const handleRepsChange = (value: string) => {
		if (/^\d*$/.test(value)) {
			const newReps = value ? parseInt(value, 10) : undefined;
			updateTrackingModel(exerciseName, { ...trackingInfo, completedReps: newReps });
		}
  };

  const handleWeightChange = (value: string) => {
    updateTrackingModel(exerciseName, { ...trackingInfo, weight: value });
  };

  const handleRpeChange = (value: string) => {
		if (/^\d*$/.test(value)) {
			const newRpe = value ? parseInt(value, 10) : undefined;
			updateTrackingModel(exerciseName, { ...trackingInfo, rpe: newRpe });
		}
  };

	useEffect(() => {
		updateTrackingModel(exerciseName, { 
			date: new Date().toISOString(), 
			weight: lastWeight,
			completedReps: parseInt(lastReps, 10),
			rpe: parseInt(lastRpe, 10),
			exerciseKey:exerciseKey 
		});
	}, []);

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
							onChangeText={handleRepsChange}>
						</TextInput>

						<TextInput style={styles.textInput}
							onChangeText={handleWeightChange}>
						</TextInput>

						<TextInput style={styles.textInput} inputMode="numeric" 
							onChangeText={handleRpeChange}>
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