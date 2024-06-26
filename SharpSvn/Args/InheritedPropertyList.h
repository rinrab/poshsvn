﻿//  Licensed under the Apache License, Version 2.0 (the "License");
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

namespace SharpSvn {

    /// <summary>Extended Parameter container for SvnClient.PropertyList</summary>
    /// <threadsafety static="true" instance="false"/>
    public ref class SvnInheritedPropertyListArgs : public SvnClientArgs
    {
        SvnRevision ^_revision;

    public:
        SvnInheritedPropertyListArgs()
        {
            _revision = SvnRevision::None;
        }

        DECLARE_EVENT(SvnInheritedPropertyListEventArgs^, List)


    public:
        property SvnRevision^ Revision
        {
            SvnRevision^ get()
            {
                return _revision;
            }
            void set(SvnRevision^ value)
            {
                if (value)
                    _revision = value;
                else
                    _revision = SvnRevision::None;
            }
        }


    protected public:
        virtual void OnList(SvnInheritedPropertyListEventArgs^ e)
        {
            List(this, e);
        }

    public:
        /// <summary>Gets the <see cref="SvnCommandType" /> of the command</summary>
        virtual property SvnCommandType CommandType
        {
            SvnCommandType get() override sealed
            {
                return SvnCommandType::InheritedPropertyList;
            }
        }
    };
}
