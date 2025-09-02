import { useAppDispatch } from 'src/core/hooks';
import { AuthState } from '../auth/auth.contracts';
import { logout } from '../auth/auth.slice';

interface AccessBlockerProps {
  authState: AuthState;
}

const AccessBlocker = ({ authState }: AccessBlockerProps) => {
  const dispatch = useAppDispatch();
  const handleLogout = () => dispatch(logout());

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center p-4">
      <div className="max-w-md w-full bg-white rounded-lg shadow-lg p-6 text-center">
        {!authState.user?.approved && (
          <>
            <div className="w-16 h-16 bg-yellow-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg className="w-8 h-8 text-yellow-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2}
                      d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.732-.833-2.5 0L4.268 18.5c-.77.833.192 2.5 1.732 2.5z" />
              </svg>
            </div>
            <h2 className="text-xl font-semibold text-gray-900 mb-2">Аккаунт на рассмотрении</h2>
            <p className="text-gray-600 mb-4">
              Ваш аккаунт еще не подтвержден администратором. Пожалуйста, ожидайте верификации.
            </p>
          </>
        )}
        {authState.user?.blocked && (
          <>
            <div className="w-16 h-16 bg-red-100 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg className="w-8 h-8 text-red-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2}
                      d="M18.364 18.364A9 9 0 005.636 5.636m12.728 12.728L5.636 5.636m12.728 12.728L5.636 5.636" />
              </svg>
            </div>
            <h2 className="text-xl font-semibold text-gray-900 mb-2">Доступ заблокирован</h2>
            <p className="text-gray-600 mb-4">
              Ваш аккаунт заблокирован. Обратитесь к администратору для получения информации.
            </p>
          </>
        )}
        <button
          onClick={handleLogout}
          className="bg-blue-600 text-white px-4 py-2 rounded-md hover:bg-blue-700 transition-colors"
        >
          Вернуться к входу
        </button>
      </div>
    </div>
  );
};

export default AccessBlocker;