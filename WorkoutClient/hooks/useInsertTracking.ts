import { useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

interface TrackingModel {
  exercises: { [key: string]: TrackingInfo };
}

interface TrackingInfo {
  date: string;
  weight?: string;
  completedReps?: number;
  rpe?: number;
  exerciseKey: string;
}

interface UseInsertTracking {
  insertTracking: (trackingModel:TrackingModel) => Promise<void>;
  loading: boolean;
  error: string | undefined;
  success: boolean;
}

const useInsertTracking = (): UseInsertTracking => {
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | undefined>(undefined);
  const [success, setSuccess] = useState<boolean>(false);

  const insertTracking = async (trackingModel:TrackingModel) => {
    setLoading(true);
    setError(undefined);

    try {
      const accessToken = await AsyncStorage.getItem('accessToken');

      const response = await fetch('http://localhost:8080/api/Tracking/InsertTracking', {
        method: 'POST',
        headers: { 
          'Content-Type': 'application/json', 
          'Authorization': `Bearer ${accessToken}`,
        },
        body: JSON.stringify(trackingModel),
      });

      if (response.ok) {
        setSuccess(true);
      } else {
        setError('Insert Tracking Failed.');
      }
    } catch (err) {
      setError('Error Trying To Insert Tracking.');
    } finally {
      setLoading(false);
    }
  };

  return { insertTracking, loading, error, success };
};

export default useInsertTracking;