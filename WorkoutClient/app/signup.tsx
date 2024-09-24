import { StyleSheet, View, Text, Pressable, TextInput } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { Separator } from "@/components/Separator";
import { useRouter } from 'expo-router';

export default function Index() {
  const router = useRouter();

  return (
    <SafeAreaView style={styles.container}>
      <Header title="Workout App!"/>
      <Separator />     

      <View style={{flex:1}}>
        <Text style={styles.title}>New Account</Text>
        <Text style={styles.text}>Sign up and workout.</Text>
      </View>

      <View style={{flex:2}}>
        <Text style={styles.text}>Email:</Text>
        <TextInput style={styles.textInput}></TextInput>
        <Text style={styles.text}>Password:</Text>
        <TextInput style={styles.textInput} secureTextEntry={true}></TextInput>
        <Text style={styles.text}>Confirm Password:</Text>
        <TextInput style={styles.textInput} secureTextEntry={true}></TextInput>
      </View>

      <View style={{flex:2}}>
        <Pressable style={styles.buttonContainer}
          onPress={() => {
            router.push('/workouts');
          }}>
          <Text style={styles.buttonText}>Create Account</Text>
        </Pressable>
      </View>
      
      <SafeAreaView style={styles.bottom}>
        <Text style={{fontSize:25, color:"#CCF6FF", textAlign:"center" }}>Have an account?</Text>
        <Pressable
          onPress={() => {
            router.push('/');
          }}>
            <Text style={{fontSize:25, color:"#EB9928", textAlign:"center", marginLeft:4 }}>Sign in</Text>
        </Pressable>
      </SafeAreaView>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 20,
    flex: 1,
    backgroundColor: "#2F4858",
  },

  text: {
    fontSize:25,
    color:'#CCF6FF',
  },

  title: {
    fontSize:50,
    fontWeight:"bold",
    color:'#CCF6FF',
  },

  bottom:{
    flexDirection:"row",
    justifyContent: "center",
    width: "100%",
    position:"absolute",
    bottom:0
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
    marginVertical:5,
	},

  buttonContainer: {
    borderWidth: 1,
		borderRadius: 5,
    backgroundColor: "#EB9928",
		borderColor: "#FFFFFF",
    height: 40,
    marginVertical:20,
  },

  buttonText: {
		fontSize: 30,
		color: "#2F4858",
    textAlign: 'center',
    fontWeight:"bold"
	},
});