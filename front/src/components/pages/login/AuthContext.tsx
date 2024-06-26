import { createContext } from "react";
import React, { useState, ReactNode } from 'react';

interface AuthContextType {
    permissao: number;
    setPermissao: (permissao: number) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [permissao, setPermissao] = useState<number>(0); // 0 representando COMUM

    return (
        <AuthContext.Provider value={{ permissao, setPermissao }}>
            {children}
        </AuthContext.Provider>
    );
};

export { AuthContext, AuthProvider };

