import { useState, useEffect } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

interface FetchOptions extends RequestInit {}

interface UseApiFetchResponse<T> {
  data: T | null;
  loading: boolean;
  error: string | null;
}

const useApiFetch = <T>(url: string, options: FetchOptions = {}): UseApiFetchResponse<T> => {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);

      try {
        const token = await AsyncStorage.getItem('accessToken');
        const headers = {
          ...options.headers,
          Authorization: token ? `Bearer ${token}` : '',
          'Content-Type': 'application/json',
        };

        const response = await fetch(url, { ...options, headers });
        if (!response.ok) {
          throw new Error(`Error: ${response.status}`);
        }
        const result = await response.json();
        setData(result);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [url]);

  return { data, loading, error };
};

export default useApiFetch;