import {useRef} from "react";


export default function SignInForm()
{
    const userRef = useRef();
    const errRef = useRef();
    
    const [userName, setUserName] = useState('');
    const [validName, setValidName] = useState(false);
    
    const [password, setPassword] = useState('');
    const [validPassword, setValidPassword] = useState(false);
    
    
    
    function signIn()
    {
        //TODO: Вход пользователя с указанными данными
    }
    
    return (
        <>
        </>
    )
}