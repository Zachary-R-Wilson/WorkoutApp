import { StyleSheet, View, Text } from "react-native";
import { SafeAreaView } from 'react-native-safe-area-context';
import { Header } from "@/components/Header";
import { Separator } from "@/components/Separator";
import { Button } from "@/components/Button";


export default function login() {
  return (
    <SafeAreaView style={styles.container}>
      <Header />
      <Separator />     

      <View>
        <Text>Login</Text>
        <Text>Sign in and workout.</Text>
        <Text>Email:</Text>

        <Text>Password:</Text>

        <Button
					route=""
					label="Login"
				/>
      </View>

      <View>
        <Text>Need an account?</Text>
        <Text>Sign up</Text>
      </View>

    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 20,
    flex: 1,
    backgroundColor: "#2F4858",
  },

});