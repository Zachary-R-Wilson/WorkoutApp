import React, { useState, useEffect } from 'react';
import { StyleSheet, ScrollView, View, TextInput, Text } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { useRouter } from 'expo-router';
import { BottomNav } from "@/components/BottomNav";
import { Separator } from "@/components/Separator";
import { BottomDrawer } from "@/components/BottomDrawer";
import { Button } from "@/components/Button";
import useBottomDrawer from '@/hooks/useBottomDrawer';

export default function NewExercise() { 
  const router = useRouter();
  const { isVisible, content, openDrawer, closeDrawer, setDrawerContent } = useBottomDrawer();
  const [exerciseName, setExerciseName] = useState('');
  const [sets, setSets] = useState('');
  const [repRange, setRepRange] = useState('');

  useEffect(() => {
    // If from edit need to pull old exercise info
  }, []);

  return (
    <SafeAreaView style={styles.container}>
      <ScrollView>
        <View style={styles.subcontainer}>
          <View style={styles.maxContainter}>
            <Text style={styles.subtitle}>Exercise Name:</Text>
          </View>
          <Separator />
          <View style={styles.inputContainter}>
            <TextInput style={styles.textInput} onChangeText={setExerciseName} value={exerciseName}></TextInput>
          </View>
        </View>

        <View style={styles.subcontainer}>
          <View style={styles.maxContainter}>
            <Text style={styles.subtitle}>How Many Sets:</Text>
          </View>
          <Separator />
          <View style={styles.inputContainter}>
            <TextInput style={styles.textInput} onChangeText={setSets} value={sets}></TextInput>
          </View>
        </View>
        
        <View style={styles.subcontainer}>
          <View style={styles.maxContainter}>
            <Text style={styles.subtitle}>Rep Range:</Text>
          </View>
          <Separator />
          <View style={styles.inputContainter}>
            <TextInput style={styles.textInput} onChangeText={setRepRange} value={repRange}></TextInput>
          </View>
        </View>

        <View style={styles.subcontainer}>
          <View style={{ width: "90%", marginVertical: 10}}>
            <Button 
              label="Create Exercise"
              pressFunc={() => {
                
              }}
            />
            <Button 
              label="Cancel"
              pressFunc={() => {
                
              }}
            />
          </View>
        </View>
      </ScrollView>
      <Separator />
      <BottomNav openDrawer={openDrawer} setDrawerContent={setDrawerContent} />

      <BottomDrawer content={content} isVisible={isVisible} closeDrawer={closeDrawer}/>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 20,
    flex: 1,
    backgroundColor: "#2F4858",
  },

  subcontainer: {
		justifyContent: "center",
		alignItems: "center",
		backgroundColor: "#EB9928",
		borderColor: "#CCF6FF",
		borderWidth: 1,
		borderRadius: 5,
		margin:10,
	},

  maxContainter: {
		flexDirection: "row",
		alignItems: "center",
		justifyContent:"center",
		position: 'relative',
		width:"100%"
	},

  inputContainter: {
		width: "90%",
		marginBottom: 10
	},

  subtitle: {
		fontSize: 30,
		fontWeight:"bold",
		color: '#2F4858',
	},

  textInput: {
		borderWidth: 1,
		borderRadius: 5,
    backgroundColor: "#CCF6FF",
		borderColor: "#FFFFFF",
    height: 40,
    textAlign:"center",
    fontSize:25,
    color:"#2F4858",
	},

  editScroll: {
    flex: 1,
    width: "90%",
    marginBottom: 10
  },

  workoutView: {
    width: "100%",
  },
});