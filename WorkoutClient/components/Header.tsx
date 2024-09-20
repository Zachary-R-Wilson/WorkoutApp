import { StyleSheet, Text } from "react-native";

export function Header() {
	const motivationText = "Looking Strong Today, Zach!";

  return (
    <Text style={styles.text}>{motivationText}</Text>
  );
}

const styles = StyleSheet.create({
  text: {
    fontSize: 50,
		fontWeight: 'bold',
		color: '#EB9928',
		
		shadowOffset: {width:1, height:1},
    shadowColor: '#CCF6FF',
    shadowOpacity: .5, 
    shadowRadius: 1,
  }
});