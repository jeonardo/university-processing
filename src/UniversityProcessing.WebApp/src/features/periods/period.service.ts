import { enqueueSnackbarError } from 'src/core';
import { setPeriod, setPeriods } from './period.slice';

/**
 * Loads periods from the API and updates the store.
 * @param dispatch Redux dispatch function
 */
export const loadPeriods = async (dispatch, fetch): Promise<void> => {
  const response = await fetch();

  if (response.error) {
    enqueueSnackbarError(response.error);
    return;
  }

  if (response?.data?.list?.length > 0) {
    const firstPeriod = response.data.list[0];
    dispatch(setPeriod(firstPeriod));
    dispatch(setPeriods(response.data.list));
  }
};