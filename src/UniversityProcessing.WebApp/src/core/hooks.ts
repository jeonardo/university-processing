import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import type { AppDispatch, RootState } from './store';
import { useEffect, useMemo, useRef } from 'react';

// Use throughout your app instead of plain `useDispatch` and `useSelector`
type DispatchFunc = () => AppDispatch
export const useAppDispatch: DispatchFunc = useDispatch;
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;

// Simple debounced callback hook based on setTimeout
export function useDebouncedCallback<T extends (...args: any[]) => void>(callback: T, delayMs: number) {
  const callbackRef = useRef<T>(callback);
  callbackRef.current = callback;

  const timeoutRef = useRef<ReturnType<typeof setTimeout> | null>(null);

  return useMemo(() => {
    const debounced = (...args: Parameters<T>) => {
      if (timeoutRef.current) {
        clearTimeout(timeoutRef.current);
      }
      timeoutRef.current = setTimeout(() => {
        callbackRef.current(...args);
      }, delayMs);
    };
    return debounced as T;
  }, [delayMs]);
}

// Требование роли Администратор. Пока только подписываемся на пользователя,
// чтобы можно было расширить логику (редирект/блокировка) при необходимости.
export function useRequireAdmin() {
  const user = useAppSelector(state => state.auth.user);
  useEffect(() => {
    // здесь потенциально можно добавить редирект/проверку approved/blocked и т.п.
  }, [user]);
}