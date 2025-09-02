const AppLoader = () => (
  <div className="fixed inset-0 z-50 flex items-center justify-center bg-gray-100 bg-opacity-80">
    <div className="flex flex-col items-center gap-4 p-6 rounded-lg shadow-md bg-white border border-gray-300">
      <div className="h-10 w-10 border-4 border-gray-400 border-t-transparent rounded-full animate-spin" />
      <span className="text-base text-gray-700 font-medium">Загрузка...</span>
    </div>
  </div>
);

export default AppLoader;
