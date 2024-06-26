﻿// Copyright 2007-2008 The SharpSvn Project
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

#pragma once

#include "..\SvnClientArgs.h"

namespace SharpSvn {

    /// <summary>Extended parameter container for <see cref="SvnClient" />Cleanup</summary>
    /// <threadsafety static="true" instance="false"/>
    public ref class SvnVacuumArgs : public SvnClientArgs
    {
        bool _includeExternals;
        bool _removeUnversionedItems;
        bool _removeIgnoredItems;
        bool _fixRrecordedTimestamps;
        bool _vacuumPristines;

    public:
        SvnVacuumArgs()
        {
        }

        property bool IncludeExternals
        {
            bool get()
            {
                return _includeExternals;
            }
            void set(bool value)
            {
                _includeExternals = value;
            }
        }

        property bool RemoveUnversionedItems
        {
            bool get()
            {
                return _removeUnversionedItems;
            }
            void set(bool value)
            {
                _removeUnversionedItems = value;
            }
        }

        property bool RemoveIgnoredItems
        {
            bool get()
            {
                return _removeIgnoredItems;
            }
            void set(bool value)
            {
                _removeIgnoredItems = value;
            }
        }

        property bool FixRrecordedTimestamps
        {
            bool get()
            {
                return _fixRrecordedTimestamps;
            }
            void set(bool value)
            {
                _fixRrecordedTimestamps = value;
            }
        }

        property bool VacuumPristines
        {
            bool get()
            {
                return _vacuumPristines;
            }
            void set(bool value)
            {
                _vacuumPristines = value;
            }
        }


        virtual property SvnCommandType CommandType
        {
            virtual SvnCommandType get() override sealed
            {
                return SvnCommandType::Vacuum;
            }
        }
    };
}
