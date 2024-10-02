import { useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

interface UseLoginResponse {
  login: (email: string, password: string) => Promise<void>;
  loading: boolean;
  error: string | undefined;
  success: boolean;
}

const useLogin = (): UseLoginResponse => {
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | undefined>(undefined);
  const [success, setSuccess] = useState<boolean>(false);

  const login = async (email: string, password: string) => {
    setLoading(true);
    setError(undefined);

    try {
      const response = await fetch('http://localhost:8080/api/Auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ 
          "Email": email,
          "Password": password,
        }),
      });

      if (response.ok) {
        const { accessToken } = await response.json();
        await AsyncStorage.setItem('accessToken', accessToken);
        setSuccess(true);
      } else {
        setError('Email or Password was incorrect.');
      }
    } catch (err) {
      setError('Error logging in');
    } finally {
      setLoading(false);
    }
  };

  return { login, loading, error, success };
};

export default useLogin;