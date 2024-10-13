import CompleteOrder from "./screens/CompleteOrder.jsx";
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

function App() {
    return <LocalizationProvider dateAdapter={AdapterDayjs}>
        <CompleteOrder></CompleteOrder>
    </LocalizationProvider>   
}

export default App;