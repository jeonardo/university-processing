import { createSlice } from "@reduxjs/toolkit";
import { CustomizationState } from "./customization.contracts";

const initialState: CustomizationState = {
    opened: false
}

const customizationSlice = createSlice({
    name: 'customization',
    initialState,
    reducers: {
        openBar: (state) => {
            state.opened = true
        },
        closeBar: (state) => {
            state.opened = false
        }
    }
})

export const { openBar, closeBar } = customizationSlice.actions

export default customizationSlice.reducer